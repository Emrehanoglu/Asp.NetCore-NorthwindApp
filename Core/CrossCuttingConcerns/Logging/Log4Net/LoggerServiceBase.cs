using log4net.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Reflection;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
	//log işlemini yapacak sınıf
	public class LoggerServiceBase
	{
		private ILog _log;
		public LoggerServiceBase(string name)
		{
			//config dosyasını okuyalım
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(File.OpenRead("log4net.config"));

			ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
				typeof(log4net.Repository.Hierarchy.Hierarchy));

			log4net.Config.XmlConfigurator.Configure(loggerRepository,xmlDocument["log4net"]);

			_log = LogManager.GetLogger(loggerRepository.Name,name);
		}
	}
}
