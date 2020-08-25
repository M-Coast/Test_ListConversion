using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Test_ListConversion
{
    public class TestList2
    {
        public class BaseType
        {
            public int B { set; get; }
        }

        public class UserType : BaseType
        {
            public int U { set; get; }
        }

        //创建协变接口，以满足Collection<UserType>到Collection<BaseType>的直接转换
        //使用out关键字
        interface INList<out T>: IEnumerable<T>, IEnumerable
        {
            T this[int index] { get; }
        }

        public class NList<T> : INList<T>, IEnumerable<T>, IEnumerable where T : BaseType
        {
            private List<T> _L = new List<T>();

            public List<T> List { get { return _L; } }

            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= _L.Count) throw new ArgumentOutOfRangeException("index");
                    return _L[index];
                }
                set
                {
                    if (index < 0 || index >= _L.Count) throw new ArgumentOutOfRangeException("index");
                    _L[index] = value;
                }
            }

            public int Count
            {
                get { return _L.Count; }
            }

            public void Add(T item)
            {
                _L.Add(item);
            }

            public void Remove(T item)
            {
                _L.Remove(item);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return _L.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }


        public void Test()
        {
            NList<UserType> ulist = new NList<UserType>();

            ulist.Add(new UserType() { B=1,U=2});

            INList<BaseType> blist = ulist;

            BaseType bi = blist[0];

            UserType ui = ulist[0];

        }
    }
}
