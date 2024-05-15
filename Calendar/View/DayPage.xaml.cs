using Calendar.View_Model;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Calendar.View
{
    /// <summary>
    /// Логика взаимодействия для DayPage.xaml
    /// </summary>
    public partial class DayPage : Page
    {
        public static EventHandler<DateArgs>? OnConcreteDaySelected;
        public static EventHandler? OnDayPageClosed;

        private DateTime currentDate;

        public DayPage()
        {
            InitializeComponent();
            InitInDayCheckBoxes();
            //DaysController.Show(currentDate);

            MountPage.OnButtonOfDayPressed += DayPage_OnButtonOfDayPressed;

            MainWindow.OnLeftButtonPressed += DayPage_OnLeftButtonPressed;
            MainWindow.OnRightButtonPressed += DayPage_OnRightButtonPressed;
            MainWindow.OnDayPageOpened += DayPage_OnDayPageOpened;
        }

        private void DayPage_OnDayPageOpened(object? sender, EventArgs e)
        {
            //List<bool> checks = DaysController.Instance.GetChecksFromDate(currentDate);
            List<bool> checks = new List<bool>() { false, false, false, false, false, false, false };

            for (int i = 0; i < 7; i++)
            {
                var element = FindName($"_{i}InDayCheckBox");

                if (element != null && element is InDayCheckBox inDayCheckBox)
                {
                    inDayCheckBox.checkBox.IsChecked = checks[i];
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        private void InitInDayCheckBoxes()
        {
            _0InDayCheckBox.label.Content = "Бег 100 метров";
            _0InDayCheckBox.image.Source = new BitmapImage(new Uri("../../../../Images/бег 100 м.png", UriKind.Relative));

            _1InDayCheckBox.label.Content = "Бег 1 километр";
            _1InDayCheckBox.image.Source = new BitmapImage(new Uri("../../../../Images/бег 1км.png", UriKind.Relative));

            _2InDayCheckBox.label.Content = "Отжимания";
            _2InDayCheckBox.image.Source = new BitmapImage(new Uri("../../../../Images/отжимания.png", UriKind.Relative));

            _3InDayCheckBox.label.Content = "Подтягивания";
            _3InDayCheckBox.image.Source = new BitmapImage(new Uri("../../../../Images/подтягивания.png", UriKind.Relative));

            _4InDayCheckBox.label.Content = "Приседания";
            _4InDayCheckBox.image.Source = new BitmapImage(new Uri("../../../../Images/приседания.png", UriKind.Relative));

            _5InDayCheckBox.label.Content = "Растяжка";
            _5InDayCheckBox.image.Source = new BitmapImage(new Uri("../../../../Images/растяжка.png", UriKind.Relative));

            _6InDayCheckBox.label.Content = "Пресс";
            _6InDayCheckBox.image.Source = new BitmapImage(new Uri("../../../../Images/пресс.png", UriKind.Relative));
        }

        // Тут уже реализовывается бэкенд, т.е. сохранение данных о данной дате
        private void DayPage_OnRightButtonPressed(object? sender, MainButtonArgs e)
        {
            if (e.ActivePage is  DayPage)
            {
                //DaysController.Save(new DayInfo(/*данные*/));
            }
        }

        // Возврат на страницу с месяцами и датами
        private void DayPage_OnLeftButtonPressed(object? sender, MainButtonArgs e)
        {
            if (e.ActivePage is DayPage)
            {
                OnDayPageClosed?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DayPage_OnButtonOfDayPressed(object? sender, DateArgs e)
        {
            currentDate = e.Date;
            OnConcreteDaySelected?.Invoke(this, new DateArgs(currentDate));
        }
    }
}
