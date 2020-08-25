using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_ListConversion
{
    public class TestList1
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
        public interface IUserTypeList<out T>
        {
            T this[int index] { get; }
            int Count { get; }
        }

        public class UserTypeList : IUserTypeList<UserType>
        {
            public List<UserType> _list = new List<UserType>();

            public List<UserType> List { get { return _list; } }

            public UserType this[int index]
            {
                get
                {
                    if (index < 0 || index >= _list.Count) throw new ArgumentOutOfRangeException("index");
                    return _list[index];
                }
            }

            public int Count
            {
                get { return _list.Count; }
            }

            public void Add(UserType item)
            {
                _list.Add(item);
            }

            public void Remove(UserType item)
            {
                _list.Remove(item);
            }
        }

        public void Test()
        {
            UserTypeList userCollection = new UserTypeList();

            IUserTypeList<UserType> IUserCollection = userCollection;

            userCollection.Add(new UserType() { B = 1, U = 2 });
            userCollection.Add(new UserType() { B = 3, U = 4 });

            IUserTypeList<BaseType> IBaseCollection = userCollection;

            BaseType b = IBaseCollection[0];

        }

    }
}
