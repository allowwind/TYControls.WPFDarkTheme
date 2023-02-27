using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TYControls
{ 
    /// DateTimePicker.xaml 的交互逻辑
    /// </summary>
    public partial class TYDateTimePicker : UserControl
    {
        public TYDateTimePicker()
        {
            InitializeComponent();
        }

        
        
        public TYDateTimePicker(string txt)
            : this()
        {

        }

        #region 事件

        /// <summary>
        /// 日历图标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconButton1_Click(object sender, RoutedEventArgs e)
        {
            if (popChioce.IsOpen == true)
            {
                popChioce.IsOpen = false;
            }

            TYDateTimeView dtView = new TYDateTimeView(DateTime);// TDateTimeView  构造函数传入日期时间
            dtView.DateTimeOK += (dateTimeStr) => //TDateTimeView 日期时间确定事件
            {
                DateTime = dateTimeStr;
                popChioce.IsOpen = false;//TDateTimeView 所在pop  关闭
            };

            popChioce.Child = dtView;
            popChioce.IsOpen = true;
        }

        /// <summary>
        /// The delete event
        /// </summary>
        public static readonly RoutedEvent TimeTextChangedEvent =
             EventManager.RegisterRoutedEvent("TimeTextChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TYDateTimePicker));

        /// <summary>
        /// 时间改变的操作.
        /// </summary>
        public event RoutedEventHandler TimeTextChanged
        {
            add
            {
                AddHandler(TimeTextChangedEvent, value);
            }

            remove
            {
                RemoveHandler(TimeTextChangedEvent, value);
            }
        }

        /// <summary>
        /// DateTimePicker 窗体登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //DateTime dt = DateTime.Now;
            //textBlock1.Text = dt.ToString("yyyy-MM-dd HH:mm:ss");//"yyyyMMddHHmmss"
            //DateTimeStr = dt;
            //  DateTime = Convert.ToDateTime(textBlock1.Text);
        }

        //public string Text
        //{
        //    get { return (string)GetValue(TextProperty); }
        //    set { SetValue(TextProperty, value); }
        //}

        //public static readonly DependencyProperty TextProperty =
        //    DependencyProperty.Register("Text", typeof(string), typeof(TYDateTimePicker), new PropertyMetadata("", OnTextChange));

        //private static void OnTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var ctrl = (d as TYDateTimePicker);
        //    var time = e.NewValue.ToString().AsTime(null);
        //    if (time == ctrl.DateTime) return;
        //    ctrl.DateTime = time;
        //}



        #endregion 事件

        #region 属性
        public DateTime? DateTime
        {
            get { return (DateTime?)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }
        public static readonly DependencyProperty DateTimeProperty =
            DependencyProperty.Register("DateTime", typeof(DateTime?), typeof(TYDateTimePicker), new PropertyMetadata(null, OnDateTimeChange));

        private static void OnDateTimeChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (d as TYDateTimePicker);
            var time = (DateTime?)e.NewValue;
            var txt = time.AsString(); 
            ctrl.txtTime.Text = txt;
        }

        #endregion 属性


    }
}