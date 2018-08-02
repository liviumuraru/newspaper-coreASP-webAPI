using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleAPI.Models
{
    public class PagedData<T>
        : IEnumerator<IEnumerable<T>>
    {
        public PagedData(IEnumerable<T> elements, int pageSize, int pageNumber)
        {
            _data = elements;
            _pageSize = pageSize;
            _pageNumber = pageNumber;
        }

        private readonly IEnumerable<T> _data;
        private int _pageNumber;
        private readonly int _pageSize;

        public virtual IEnumerable<T> Current
        {
            get
            {
                var list = new List<T>();
                list.AddRange(_data.Skip(_pageNumber * _pageSize).Take(_pageSize));
                return list;
            }
        }

        public virtual bool MoveNext()
        {
            _pageNumber++;
            if (_data.Skip(_pageNumber * _pageSize).Take(_pageSize).Count() <= 0)
                return false;
            return true;
        }

        public virtual void Reset()
        {
            _pageNumber = 0;
        }

        public virtual void Dispose()
        {
            
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public string ToJSON() => JsonConvert.SerializeObject(this,
                                 new JsonSerializerSettings
                                 {
                                     ContractResolver = new
                                                            CamelCasePropertyNamesContractResolver()
                                 });
    }
}
