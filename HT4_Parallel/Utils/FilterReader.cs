using HT4_Parallel.DataSource;
using System;
using System.IO;
using System.Xml.Serialization;

namespace HT4_Parallel.Utils
{
    class FilterReader
    {
        private Filter filter;

        public FilterReader()
        {
            this.filter = ReadFromXMLFile();
        }

        private Filter ReadFromXMLFile()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Filter));
            try
            {
                string path = Directory.GetCurrentDirectory();
                path = path.Substring(0, path.Length - 17);
                path = Path.Combine(path, @"DataSource\Filter.xml");
                using (Stream fStream = File.OpenRead(path))
                {
                    return (Filter)xmlFormat.Deserialize(fStream);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Can`t open filter file");
                return null;
            }
        }

        public int GetCategoryProducts()
        {
            return filter.categoryProducts;
        }

        public string Getitem()
        {
            return filter.item;
        }

        public string Getproducer()
        {
            return filter.producer;
        }

        public int GetSort()
        {
            return filter.sort;
        }
        public int GetNumberProduct()
        {
            return filter.numberProduct;
        }

        public int GetNumberPrice()
        {
            return filter.price;
        }

        public static Filters ReadFiltersFromXML()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Filters));
            try
            {
                string path = Directory.GetCurrentDirectory();
                path = path.Substring(0, path.Length - 17);
                path = Path.Combine(path, @"DataSource\Filters.xml");
                using (Stream fStream = File.OpenRead(path))
                {
                    return (Filters)xmlFormat.Deserialize(fStream);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Can`t open filters file");
                return null;
            }
        }
    }
}
