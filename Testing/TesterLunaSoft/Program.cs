using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesterLunaSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Init App");
            string xmlb64 = "77u/PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4NCjxjZmRpOkNvbXByb2JhbnRlIHhzaTpzY2hlbWFMb2NhdGlvbj0iaHR0cDovL3d3dy5zYXQuZ29iLm14L2NmZC8zIGh0dHA6Ly93d3cuc2F0LmdvYi5teC9zaXRpb19pbnRlcm5ldC9jZmQvMy9jZmR2MzIueHNkIiB2ZXJzaW9uPSIzLjIiIHNlcmllPSJHIiBmb2xpbz0iMSIgTHVnYXJFeHBlZGljaW9uPSJHVUFEQUxBSkFSQSwgSkFMSVNDTyIgTnVtQ3RhUGFnbz0iODQyNyIgZmVjaGE9IjIwMTQtMDktMTBUMTI6MjA6MTIiIHNlbGxvPSIiIGZvcm1hRGVQYWdvPSJQYWdvIGVuIHVuYSBzb2xhIGV4aGliaWNpw7NuIiBub0NlcnRpZmljYWRvPSIiIGNlcnRpZmljYWRvPSIiIHN1YlRvdGFsPSIxLjAwMDAwMCIgVGlwb0NhbWJpbz0iMS4wMDAwIiBNb25lZGE9Ik1YTiIgdG90YWw9IjEuMTYwMDAwIiBtZXRvZG9EZVBhZ289IlRyYW5zZmVyZW5jaWEgRWxlY3Ryw7NuaWNhIiB0aXBvRGVDb21wcm9iYW50ZT0iaW5ncmVzbyIgeG1sbnM6Y2ZkaT0iaHR0cDovL3d3dy5zYXQuZ29iLm14L2NmZC8zIiB4bWxuczp4c2k9Imh0dHA6Ly93d3cudzMub3JnLzIwMDEvWE1MU2NoZW1hLWluc3RhbmNlIj4NCiAgPGNmZGk6RW1pc29yIHJmYz0iQUFEOTkwODE0QlA3IiBub21icmU9IkVNUFJFU0EgREVNTyBTQSBERSBDViI+DQogICAgPGNmZGk6RG9taWNpbGlvRmlzY2FsIGNhbGxlPSJDQUxMRSBERU1PIiBub0V4dGVyaW9yPSIxMjM0IiBub0ludGVyaW9yPSJBQSIgY29sb25pYT0iQ09MT05JQSBERU1PIiBsb2NhbGlkYWQ9IkdVQURBTEFKQVJBIiBtdW5pY2lwaW89IkdVQURBTEFKQVJBIiBlc3RhZG89IkpBTElTQ08iIHBhaXM9Ik3DqXhpY28iIGNvZGlnb1Bvc3RhbD0iOTAyMTAiIC8+DQogICAgPGNmZGk6UmVnaW1lbkZpc2NhbCBSZWdpbWVuPSJSw6lnaW1lbiBkZSBsYXMgUGVyc29uYXMgRsOtc2ljYXMgY29uIEFjdGl2aWRhZGVzIEVtcHJlc2FyaWFsZXMgeSBQcm9mZXNpb25hbGVzIiAvPg0KICA8L2NmZGk6RW1pc29yPg0KICA8Y2ZkaTpSZWNlcHRvciByZmM9IkFQUjA0MTIxMDhDNSIgbm9tYnJlPSJFTVBSRVNBIERFTU8gUkVDRVBUT1IiPg0KICAgIDxjZmRpOkRvbWljaWxpbyBjYWxsZT0iQ0FMTEUgREVNTyBSRUNFUFRPUiIgbm9FeHRlcmlvcj0iMTIzNCIgbm9JbnRlcmlvcj0iQUEiIGNvbG9uaWE9IkNPTE9OSUEgREVNTyBSRUNFUFRPUiIgbG9jYWxpZGFkPSJaQVBPUEFOIiBtdW5pY2lwaW89IlpBUE9QQU4iIGVzdGFkbz0iSkFMSVNDTyIgcGFpcz0iTUVYSUNPIiBjb2RpZ29Qb3N0YWw9IjkwMjEwIiAvPg0KICA8L2NmZGk6UmVjZXB0b3I+DQogIDxjZmRpOkNvbmNlcHRvcz4NCiAgICA8Y2ZkaTpDb25jZXB0byBjYW50aWRhZD0iMSIgdW5pZGFkPSJObyBBcGxpY2EiIGRlc2NyaXBjaW9uPSJTZXJ2aWNpbyBEZW1vIiB2YWxvclVuaXRhcmlvPSIxLjAwMDAwMCIgaW1wb3J0ZT0iMS4wMDAwMDAiIC8+DQogIDwvY2ZkaTpDb25jZXB0b3M+DQogIDxjZmRpOkltcHVlc3RvcyB0b3RhbEltcHVlc3Rvc1RyYXNsYWRhZG9zPSIwLjE2MDAwMCI+DQogICAgPGNmZGk6VHJhc2xhZG9zPg0KICAgICAgPGNmZGk6VHJhc2xhZG8gaW1wdWVzdG89IklWQSIgdGFzYT0iMTYiIGltcG9ydGU9IjAuMTYwMDAwIiAvPg0KICAgIDwvY2ZkaTpUcmFzbGFkb3M+DQogIDwvY2ZkaTpJbXB1ZXN0b3M+DQogIDxjZmRpOkNvbXBsZW1lbnRvPjwvY2ZkaTpDb21wbGVtZW50bz4NCjwvY2ZkaTpDb21wcm9iYW50ZT4=";
            string cerb64 = "MIIE2jCCA8KgAwIBAgIUMjAwMDEwMDAwMDAyMDAwMDAyOTMwDQYJKoZIhvcNAQEFBQAwggFcMRowGAYDVQQDDBFBLkMuIDIgZGUgcHJ1ZWJhczEvMC0GA1UECgwmU2VydmljaW8gZGUgQWRtaW5pc3RyYWNpw7NuIFRyaWJ1dGFyaWExODA2BgNVBAsML0FkbWluaXN0cmFjacOzbiBkZSBTZWd1cmlkYWQgZGUgbGEgSW5mb3JtYWNpw7NuMSkwJwYJKoZIhvcNAQkBFhphc2lzbmV0QHBydWViYXMuc2F0LmdvYi5teDEmMCQGA1UECQwdQXYuIEhpZGFsZ28gNzcsIENvbC4gR3VlcnJlcm8xDjAMBgNVBBEMBTA2MzAwMQswCQYDVQQGEwJNWDEZMBcGA1UECAwQRGlzdHJpdG8gRmVkZXJhbDESMBAGA1UEBwwJQ295b2Fjw6FuMTQwMgYJKoZIhvcNAQkCDCVSZXNwb25zYWJsZTogQXJhY2VsaSBHYW5kYXJhIEJhdXRpc3RhMB4XDTEyMTAyNjE5MjI0M1oXDTE2MTAyNjE5MjI0M1owggFTMUkwRwYDVQQDE0BBU09DSUFDSU9OIERFIEFHUklDVUxUT1JFUyBERUwgRElTVFJJVE8gREUgUklFR08gMDA0IERPTiBNQVJUSU4gMWEwXwYDVQQpE1hBU09DSUFDSU9OIERFIEFHUklDVUxUT1JFUyBERUwgRElTVFJJVE8gREUgUklFR08gMDA0IERPTiBNQVJUSU4gQ09BSFVJTEEgWSBOVUVWTyBMRU9OIEFDMUkwRwYDVQQKE0BBU09DSUFDSU9OIERFIEFHUklDVUxUT1JFUyBERUwgRElTVFJJVE8gREUgUklFR08gMDA0IERPTiBNQVJUSU4gMSUwIwYDVQQtExxBQUQ5OTA4MTRCUDcgLyBIRUdUNzYxMDAzNFMyMR4wHAYDVQQFExUgLyBIRUdUNzYxMDAzTURGUk5OMDkxETAPBgNVBAsTCFNlcnZpZG9yMIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDlrI9loozd+UcW7YHtqJimQjzX9wHIUcc1KZyBBB8/5fZsgZ/smWS4Sd6HnPs9GSTtnTmM4bEgx28N3ulUshaaBEtZo3tsjwkBV/yVQ3SRyMDkqBA2NEjbcum+e/MdCMHiPI1eSGHEpdESt55a0S6N24PW732Xm3ZbGgOp1tht1wIDAQABox0wGzAMBgNVHRMBAf8EAjAAMAsGA1UdDwQEAwIGwDANBgkqhkiG9w0BAQUFAAOCAQEAuoPXe+BBIrmJn+IGeI+m97OlP3RC4Ct3amjGmZICbvhI9BTBLCL/PzQjjWBwU0MG8uK6e/gcB9f+klPiXhQTeI1YKzFtWrzctpNEJYo0KXMgvDiputKphQ324dP0nzkKUfXlRIzScJJCSgRw9ZifKWN0D9qTdkNkjk83ToPgwnldg5lzU62woXo4AKbcuabAYOVoC7owM5bfNuWJe566UzD6i5PFY15jYMzi1+ICriDItCv3S+JdqyrBrX3RloZhdyXqs2Htxfw4b1OcYboPCu4+9qM3OV02wyGKlGQMhfrXNwYyj8huxS1pHghEROM2Zs0paZUOy+6ajM+Xh0LX2w==";
            string keyb64 = "MIICxjBABgkqhkiG9w0BBQ0wMzAbBgkqhkiG9w0BBQwwDgQI72h4KDEzKngCAggAMBQGCCqGSIb3DQMHBAhnTm885oeZqQSCAoDpmVOMNUX5HWKrwiEoz3XqG1OD5GUkMJy01Ljrj/XpwiyMr7sckuYNVwUU0t/kTyjfvA6sJ3LAM0nb0F3aZSyyKdBXZS9KtpzaoKrIA2ZRT9QZt2BYLFnR0xmydsR40UJuVu5+XCtjOQiO8VL45qsUPXAA0FWcSJkFMgyV0jAwlu9YD41ryLOEtdrBnLQQ0nePzfOlwT6fyIeiGp3cHvE7O2bKBIn0W+8CQ3tNHL1DMxf2i9Lp+QhFJCUKMO6syXPfHRcaG8b0o/NeVU1f2cyIJ7M3rIVzAzarvGLxkw/T9BexzcOAQJAeONGlkUjUl1h16a4UEsHtdJSzoxm9xdrvGVLAJL+nmguGknSutaNk7QsjhXJtoIomJ9xhttSIEhwIMMsaPZgJ0DsDUJFh5CXjnjWEi06nwWW56ONPHz5P7zghA4iYVVwMbm+fXHpKDHeJh9tkOHvQ94rGpGBpKzVWZokCNYv7b5o6M+RKO7cjqI/iPLyl0+IWBTE1YUaKGuF5FlbxbBpyeHSX5LKuLHTkJexIVMIkkS4AWQnxIAecLgbd8SK9WATwwz+B2zYN08NhVAazQNAXYS/SYVt4RZzG6SdUwGBSdKgh7dXWFxc0NPgJc1zovk7Uafb1xxFNasw9wK2bcn/bk2J9dt3gyoSa8G4jeI2cr0T1ZruVi6JQ+lxCqUihraTBksY86L7vDX7PAgeKs2BHxK8NgwmGilz6pouBsnelhB4tJU0wcrVqLUQ2CI2HIxs/hFH2ATJSxfmfZQg6XBTcFWFb8QdA2t2vQ5aSy7kjc1z4XhzbKkoORx6AbZ2YqjXveKzGxHup4Wz0Cg8cWnOtCMyTjXNE3yMN";
            string password = "12345678a";
            LunaSoft.StampClient.IValidationService validationService = new LunaSoft.StampClient.ValidationService();
            LunaSoft.StampClient.IStampClientService stampService = new LunaSoft.StampClient.StampClientService();

            try
            {
                string xml = Encoding.UTF8.GetString(Convert.FromBase64String(xmlb64));
                var comprobante = validationService.LoadInvoice(xml);
                comprobante.fecha = DateTime.Now.AddMinutes(-5);
                var resultSign =
                    stampService.SignInvoice(Convert.FromBase64String(cerb64), Convert.FromBase64String(keyb64),
                    password, comprobante);

                if (resultSign.HasError)
                    throw new Exception(resultSign.ErrorMessage);

                var resultStamped = stampService.Stamp(resultSign.InvoiceSigned);
                if (resultStamped.HasError)
                    throw new Exception(resultStamped.ErrorMessage);

                Console.WriteLine(string.Format("Stamped OK UUID:{0}", resultStamped.TFD.UUID));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
