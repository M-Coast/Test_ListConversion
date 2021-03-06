﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_ListConversion
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Test1();

            Test2();
        }

        public void Test1()
        {
            List<UserType> LU;
            List<BaseType> LB;

            LU = new List<UserType>();
            LU.Add(new UserType() { B = 1, U = 2 });
            LU.Add(new UserType() { B = 1, U = 2 });
            LU.Add(new UserType() { B = 1, U = 2 });
            LU.Add(new UserType() { B = 1, U = 2 });


            //这样转换编译错误
            //l0 = (List<TBase>)l2;
            //l0 = l2 as List<TBase>();

            //从子类转换父类，以下方式均工作
            LB = LU.ConvertAll(i => i as BaseType);    
            LB = LU.ConvertAll(i => (BaseType)i);     
            LB = LU.ConvertAll<BaseType>(i => i as BaseType); 
            LB = LU.Cast<BaseType>().ToList();



            List<BaseType> LB2;
            List<UserType> LU2;

            LB2 = new List<BaseType>();
            LB2.Add(new BaseType() { B = 1 });
            LB2.Add(new BaseType() { B = 1 });
            LB2.Add(new BaseType() { B = 1 });
            LB2.Add(new BaseType() { B = 1 });

            //从父类转换子类，以下方式均不工作，转换过后为NULL或报异常
            LU2 = LB2.ConvertAll<UserType>(i => i as UserType);
            LU2 = LB2.ConvertAll(i => i as UserType);
            //LU2 = LB2.ConvertAll(i => (UserType)i);   //Exception

        }


        private void Test2()
        {
            TestList1 t1 = new TestList1();
            t1.Test();

            TestList2 t2 = new TestList2();
            t2.Test();

        }

    }
}
