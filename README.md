LunaSoft.StampClient
====================

Cliente C# .net 4.0 para el timbrado con LunaSoft PCC #16543

##Configuración

La libreria de timbrado utiliza un archivo de configuracion StampClient.config , el cual contiene la información necesaria para conectarse a los servicios de timbrado de Luna Soft. Es importante sustiuir la informacion contenida en este archivo dependiendo de el ambiente en el que se este trabajando, por default se proporcionan los datos de pruebas.

##Ambiente productivo

Dentro del Archivo StampClient.config es necesario sustituir las llaves : 

    *PathSat -> Extras\CertificadoSAT_productivo\
    *URLStampingLS -> [url timbrado productivo proporcionada por el PAC]
    *URLCancelacionLS -> [url cancelación productivo proporcionada por el PAC]
    *URLAutenticateLS -> [url autenticacion productivo proporcionada por el PAC]
    *UserLS -> [usuario de timbrado productivo]
    *PassLS -> [contraseña de timbrado productivo]
