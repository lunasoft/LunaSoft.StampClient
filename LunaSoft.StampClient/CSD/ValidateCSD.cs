using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using LunaSoft.StampClient.Entities;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System.Text.RegularExpressions;

namespace LunaSoft.StampClient.CSD
{
    internal class ValidateCSD
    {
        private string ACPRUEBAS = @"CN=A\.C\..*DE PRUEBAS";
        static ObjectCache cache = MemoryCache.Default;
        /// <summary>
        /// Validacion del Certificado y Llave Privada.
        /// </summary>
        /// <param name="bCER"></param>
        /// <param name="rfc"></param>
        /// <param name="bKEY"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal ValidateCerResponse Certificate(byte[] bCER, string rfc, byte[] bKEY, string password)
        {
            var result = new ValidateCerResponse();
            try
            {
                X509Certificate2 certX509 = default(X509Certificate2);

                //Make the pfx file
                byte[] pfx = MakeCert.generatePFX(bCER, bKEY, password);
                result.PFX = (byte[])pfx.Clone();

                certX509 = new X509Certificate2(pfx, password, X509KeyStorageFlags.MachineKeySet);

                if (null != certX509)
                {
                    //Validate if key and cer match pair using BouncyCastle
                    X509Certificate2 c = new X509Certificate2(bCER);
                    Org.BouncyCastle.X509.X509Certificate cert = CSD.DotNetUtilities.FromX509Certificate(c);
                    RsaKeyParameters publicKey = (RsaKeyParameters)cert.GetPublicKey();

                    AsymmetricKeyParameter asymmetricKeyParameter = PrivateKeyFactory.DecryptKey(password.ToCharArray(), bKEY);
                    RsaPrivateCrtKeyParameters privateKey = (RsaPrivateCrtKeyParameters)asymmetricKeyParameter;

                    if (!(privateKey.Modulus.Equals(publicKey.Modulus)))
                        result.AddError("No hay Correspondencia entre el Certificado y la Llave Privada.");
                    var notEmitido = certificateIssuedBySat(bCER);
                    if (!notEmitido)
                        result.AddError("El Certificado no fue emitido por el SAT.");
                    if ((DateTime.Now > certX509.NotAfter) || (DateTime.Now < certX509.NotBefore))
                        result.AddError("La vigencia del Certificado no es valida.");
                    if (this.isFiel(certX509) && rfc.Length == 12)
                        result.AddError("Este Certificado es una fiel y no es permitido para Personas Morales.");
                    if (!certX509.HasPrivateKey)
                        result.AddError("La contraseña y/o llave privada no son validas.");
                    if (!certX509.Subject.ToUpper().Contains(rfc.ToUpper()) || rfc.Length < 12)
                        result.AddError("El Certificado no pertenece al contribuyente.");
                    if (Regex.IsMatch(certX509.Issuer.ToUpper(), ACPRUEBAS))
                        result.AddWarning("El Certificado es de pruebas.");

                    result.IsFiel = this.isFiel(certX509);
                    result.IsDemo = Regex.IsMatch(certX509.Issuer.ToUpper(), ACPRUEBAS);

                    //Info Certificate
                    result.SerialNumber = Etc.CertUtil.getCertNumber(certX509);
                    result.NotBefore = certX509.NotBefore;
                    result.NotAfter = certX509.NotAfter;
                    result.SubjectName = certX509.SubjectName != null ? certX509.SubjectName.Name : "";
                    result.IssuerName = certX509.IssuerName != null ? certX509.IssuerName.Name : "";
                }

            }
            catch (Exception ex)
            {
                var e = ex;
                result.AddError("Los Datos proporcionados son incorrectos y/o La Contraseña es incorrecta.");

            }
            return result;
        }
        /// <summary>
        /// Validacion del Certificado
        /// </summary>
        /// <param name="bCER"></param>
        /// <returns></returns>
        internal ValidateCerResponse Certificate(byte[] bCER)
        {
            var result = new ValidateCerResponse();
            try
            {
                X509Certificate2 certX509 = default(X509Certificate2);

                if (null != certX509)
                {
                    //Validate if key and cer match pair using BouncyCastle
                    X509Certificate2 c = new X509Certificate2(bCER);
                    Org.BouncyCastle.X509.X509Certificate cert = CSD.DotNetUtilities.FromX509Certificate(c);
                    RsaKeyParameters publicKey = (RsaKeyParameters)cert.GetPublicKey();

                    var notEmitido = certificateIssuedBySat(bCER);
                    if (!notEmitido)
                        result.AddError("El Certificado no fue emitido por el SAT.");
                    if ((DateTime.Now > certX509.NotAfter) || (DateTime.Now < certX509.NotBefore))
                        result.AddError("La vigencia del Certificado no es valida.");
                    if (Regex.IsMatch(certX509.Issuer.ToUpper(), ACPRUEBAS))
                        result.AddWarning("El Certificado es de pruebas.");

                    result.IsFiel = this.isFiel(certX509);
                    result.IsDemo = Regex.IsMatch(certX509.Issuer.ToUpper(), ACPRUEBAS);

                    //Info Certificate
                    result.SerialNumber = Etc.CertUtil.getCertNumber(certX509);
                    result.NotBefore = certX509.NotBefore;
                    result.NotAfter = certX509.NotAfter;
                    result.SubjectName = certX509.SubjectName != null ? certX509.SubjectName.Name : "";
                    result.IssuerName = certX509.IssuerName != null ? certX509.IssuerName.Name : "";
                }

            }
            catch (Exception)
            {
                result.AddError("Los Datos proporcionados son incorrectos y/o La Contraseña es incorrecta.");
            }
            return result;
        }
        /// <summary>
        /// Valida Certificado o Password
        /// </summary>
        /// <param name="bCER"></param>
        /// <param name="rfc"></param>
        /// <param name="bKEY"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal ValidateCerResponse ValidateCertificatePassword(byte[] bCER, string rfc, byte[] bKEY, string password)
        {
            var result = new ValidateCerResponse();

            X509Certificate2 certX509 = default(X509Certificate2);
            try
            {
                //Make the pfx file
                byte[] pfx = MakeCert.generatePFX(bCER, bKEY, password);
                result.PFX = (byte[])pfx.Clone();

                certX509 = new X509Certificate2(pfx, password, X509KeyStorageFlags.MachineKeySet);

                if (null != certX509)
                {
                    if (!certX509.HasPrivateKey)
                        result.AddError("La contraseña y/o llave privada no son validas.");
                    if (!certX509.Subject.ToUpper().Contains(rfc.ToUpper()) || rfc.Length < 12)
                        result.AddError("El Certificado no pertenece al contribuyente.");

                    //Info Certificate
                    result.SerialNumber = Etc.CertUtil.getCertNumber(certX509);
                    result.NotBefore = certX509.NotBefore;
                    result.NotAfter = certX509.NotAfter;
                    result.SubjectName = certX509.SubjectName != null ? certX509.SubjectName.Name : "";
                    result.IssuerName = certX509.IssuerName != null ? certX509.IssuerName.Name : "";
                }
            }
            catch (Exception ex)
            {
                result.AddError("Error no controlado en la validación del Certificado." + ex.Message);
            }
            return result;
        }        
        private bool isFiel(X509Certificate2 certX509)
        {
            X509KeyUsageExtension keyUsageExtension;
            string KeyUsages;
            bool esFiel = false;

            for (int i = 0; i <= certX509.Extensions.Count; i++)
            {
                try
                {
                    keyUsageExtension = certX509.Extensions[i] as X509KeyUsageExtension;
                    if (null != keyUsageExtension)
                    {
                        KeyUsages = keyUsageExtension.KeyUsages.ToString();

                        if (keyUsageExtension.KeyUsages.ToString().Contains("KeyAgreement") || keyUsageExtension.KeyUsages.ToString().Contains("DataEncipherment"))
                        {
                            esFiel = true;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return esFiel;
        }
        private bool certificateIssuedBySat(byte[] certificateValidate)
        {
            bool validation = false;
            Mono.Security.X509.X509CertificateCollection collection = new Mono.Security.X509.X509CertificateCollection();
            Mono.Security.X509.X509Certificate certt = new Mono.Security.X509.X509Certificate(certificateValidate);
            Mono.Security.X509.X509Chain xchan = new Mono.Security.X509.X509Chain();
            collection = GetCollection();

            xchan.TrustAnchors = collection;
            validation = xchan.Build(certt);

            if (!validation && xchan.Status == Mono.Security.X509.X509ChainStatusFlags.NotTimeNested)
            {
                validation = true;
            }
            return validation;
        }
        private Mono.Security.X509.X509CertificateCollection GetCollection()
        {
            Mono.Security.X509.X509CertificateCollection value =
                (Mono.Security.X509.X509CertificateCollection)cache["CerRootCollection"];
            if (value == null)
            {
                string pathSat = Implement.ConfigValue.Get("PathSat");
                string fullPath = Etc.FileUtil.GetAppDirectory(pathSat);
                value = new Mono.Security.X509.X509CertificateCollection();

                if (Directory.Exists(fullPath))
                {
                    var files = Directory.GetFiles(fullPath);
                    foreach (var item in files)
                    {
                        if (item.ToLower().EndsWith(".cer") || item.ToLower().EndsWith(".crt"))
                        {
                            var caCertificate = GetBytesFile(item);
                            value.Add(new Mono.Security.X509.X509Certificate(caCertificate));
                        }
                    }
                    if (value.Count > 0)
                    {
                        CacheItemPolicy notExpiringPolicy = new CacheItemPolicy();
                        cache.Set("CerRootCollection", value, notExpiringPolicy);
                    }

                }
            }
            return value;
        }
        private byte[] GetBytesFile(string pathFile)
        {
            byte[] value;
            value = (byte[])cache.Get(pathFile);
            if (value == null)
            {
                CacheItemPolicy filePolicy = new CacheItemPolicy();
                filePolicy.ChangeMonitors.Add(new HostFileChangeMonitor(new List<string> { pathFile }));
                value = File.ReadAllBytes(pathFile);
                cache.Set(pathFile, value, filePolicy);
            }
            return value;

        }
    }
}
