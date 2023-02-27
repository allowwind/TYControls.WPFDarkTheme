using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace TYControls
{
    [System.ComponentModel.DesignTimeVisible(false)]//在工具箱中 隐藏该窗体
    /// <summary>
    /// TDateTime.xaml 的交互逻辑
    /// </summary>
    public partial class TYDateTimeView : UserControl
    {
        public TYDateTimeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="txt"></param>
        public TYDateTimeView(DateTime? txt)
            : this()
        {
            InitializeComponent();
            this.formerDateTimeStr = txt;
        }

        #region 全局变量

        /// <summary>
        /// 从 DateTimePicker 传入的日期时间字符串
        /// </summary>
        private DateTime? formerDateTimeStr = null;

        // private string selectDate = string.Empty;

        #endregion 全局变量

        #region 事件

        /// <summary>
        /// TDateTimeView 窗体登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //当前时间
            DateTime dt = DateTime.Now;
            if (formerDateTimeStr != null)
            {
                dt = this.formerDateTimeStr.Value;
            }

            btnhh.Content = dt.Hour.ToString().PadLeft(2, '0');
            btnmm.Content = dt.Minute.ToString().PadLeft(2, '0');
            btnss.Content = dt.Second.ToString().PadLeft(2, '0');
            calDate.SelectedDate = dt;
        }

        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBtnCloseView_Click(object sender, RoutedEventArgs e)
        {
            if (formerDateTimeStr != null)
            {
                OnDateTimeContent(this.formerDateTimeStr.Value);
            }
        }

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dt = new DateTime?();

            if (calDate.SelectedDate == null)
            {
                dt = DateTime.Now.Date;
            }
            else
            {
                dt = calDate.SelectedDate;
            }

            DateTime dtCal = Convert.ToDateTime(dt);

            int.TryParse(btnhh.Content.ToString(), out int hour);
            int.TryParse(btnmm.Content.ToString(), out int minu);
            int.TryParse(btnss.Content.ToString(), out int second);
            dtCal.AddHours(hour);
            dtCal.AddMinutes(minu);
            dtCal.AddSeconds(second);
            OnDateTimeContent(dtCal);
        }

        /// <summary>
        /// 当前按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNow_Click(object sender, RoutedEventArgs e)
        {
            popChioce.IsOpen = false;//THourView 或 TMinSexView 所在pop 的关闭动作
            calDate.SelectedDate = DateTime.Now;
            if (btnNow.Content.ToString() == "零点")
            {
                btnhh.Content = "00";
                btnmm.Content = "00";
                btnss.Content = "00";
                btnNow.Content = "当前"; 
            }
            else
            {
                DateTime dt = DateTime.Now;
                btnhh.Content = dt.Hour.ToString().PadLeft(2, '0');
                btnmm.Content = dt.Minute.ToString().PadLeft(2, '0');
                btnss.Content = dt.Second.ToString().PadLeft(2, '0');
                btnNow.Content = "零点"; 
            }
        }

        /// <summary>
        /// 小时点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnhh_Click(object sender, RoutedEventArgs e)
        {
            if (popChioce.IsOpen == true)
            {
                popChioce.IsOpen = false;
            }

            TYHourView hourView = new TYHourView(btnhh.Content.ToString());// THourView 构造函数传递小时数据
            hourView.HourClick += (hourstr) => //THourView 点击所选小时后的 传递动作
            {
                btnhh.Content = hourstr;
                popChioce.IsOpen = false;//THourView 所在pop 的关闭动作
            };

            popChioce.Child = hourView;
            popChioce.IsOpen = true;

            //View 退出事件
            //HG.ViewClose += (Flag) =>
            //{
            //    popChioce.IsOpen = false;

            //};
        }

        /// <summary>
        /// 分钟点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnmm_Click(object sender, RoutedEventArgs e)
        {
            if (popChioce.IsOpen == true)
            {
                popChioce.IsOpen = false;
            }

            TYMinSexView minView = new TYMinSexView(btnmm.Content.ToString());//TMinSexView 构造函数传递 分钟数据
            minView.MinClick += (minStr) => //TMinSexView 中 点击选择的分钟数据的 传递动作
            {
                btnmm.Content = minStr;
                popChioce.IsOpen = false;//TMinSexView 所在的 pop 关闭动作
            };

            popChioce.Child = minView;
            popChioce.IsOpen = true;
        }

        /// <summary>
        /// 解除calendar点击后 影响其他按钮首次点击无效的问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calDate_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.Captured is CalendarItem)
            {
                Mouse.Capture(null);
            }
        }

        #endregion 事件

        #region Action交互

        /// <summary>
        /// 时间确定后的传递事件
        /// </summary>
        public Action<DateTime> DateTimeOK;

        /// <summary>
        /// 时间确定后传递的时间内容
        /// </summary>
        /// <param name="dateTimeStr"></param>
        protected void OnDateTimeContent(DateTime dateTimeStr)
        {
            if (DateTimeOK != null)
                DateTimeOK(dateTimeStr);
        }

        #endregion Action交互

        /// <summary>
        /// 秒钟点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnss_Click(object sender, RoutedEventArgs e)
        {
            if (popChioce.IsOpen == true)
            {
                popChioce.IsOpen = false;
            }

            //秒钟 跟分钟 都是60，所有秒钟共用 分钟的窗体即可
            TYMinSexView sexView = new TYMinSexView(btnss.Content.ToString());//TMinSexView 构造函数 传入秒钟数据
            sexView.textBlockTitle.Text = "秒    钟";//修改 TMinSexView 的标题名称为秒钟
            sexView.MinClick += (sexStr) => //TMinSexView 中 所选择确定的 秒钟数据 的传递动作
            {
                btnss.Content = sexStr;
                popChioce.IsOpen = false;//TMinSexView 所在的 pop 关闭动作
            };

            popChioce.Child = sexView;
            popChioce.IsOpen = true;
        }
    }
}