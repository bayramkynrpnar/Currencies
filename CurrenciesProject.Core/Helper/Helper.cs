using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CurrenciesProject.Core.Helper
{
    public class Helper
    {
        #region Singleton Section

        private static readonly Lazy<Helper> _instance = new Lazy<Helper>(() => new Helper());

        private Helper()
        {
        }

        public static Helper Instance => _instance.Value;

        #endregion

        /// <summary>
        /// Verilen xml stringi verilen modele deserialize işlemi yapar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public T XmlDeserialize<T>(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlString))
            {
                var test = (T)serializer.Deserialize(reader);
                return test;
            }
        }

        /// <summary>
        /// Verilen iki sayı arasındaki yüzdelik değişimi bulur
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public string CalculatePercentage(double one, double two)
        {
            var result = two - one;
            result = ((result / one) * 100);
            result = Math.Round(result, 2);
            return $"{result}%";
        }

        /// <summary>
        /// TCMB servisine istek atarak o güne ait xmli string döner
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetData()
        {
            string getCurrenciesService = "https://www.tcmb.gov.tr/kurlar/today.xml";
            RestClient client = new RestClient(getCurrenciesService);
            RestRequest request = new RestRequest();
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
