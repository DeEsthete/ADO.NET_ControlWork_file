using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibr.Service
{
    public class DocumentService
    {
        public void Create(Document item)
        {
            using (Cloud9Model context = new Cloud9Model())
            {
                context.Documents.Add(item);
                context.SaveChanges();
            }
        }

        public List<Document> SelectAll()
        {
            List<Document> temp;
            using (Cloud9Model context = new Cloud9Model())
            {
                temp = context.Documents.ToList();
            }
            return temp;
        }

        public Document Select(int id)
        {
            Document result = new Document();
            using (Cloud9Model context = new Cloud9Model())
            {
                List<Document> temp = context.Documents.ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].Id == id)
                    {
                        result = temp[i];
                    }
                }
            }
            return result;
        }

        public void Update(Document product)
        {
            using (Cloud9Model context = new Cloud9Model())
            {
                context.Entry(product).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Document result = new Document();
            using (Cloud9Model context = new Cloud9Model())
            {
                List<Document> temp = context.Documents.ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].Id == id)
                    {
                        context.Documents.Remove(temp[i]);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
