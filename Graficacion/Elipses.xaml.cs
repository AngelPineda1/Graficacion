using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Graficacion
{
    /// <summary>
    /// Lógica de interacción para Elipses.xaml
    /// </summary>
    public partial class Elipses : Window
    {
        public Elipses()
        {
            InitializeComponent();
        }
        Ellipse elipse;
        private void cnvElipses_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point posicion = e.GetPosition(cnvElipses);
            Random r = new Random();
             elipse = new Ellipse
            {
                Width = 30,
                Height = 30,
                Fill=new SolidColorBrush(Color.FromRgb((byte)r.Next(0,256), (byte)r.Next(0, 256), (byte)r.Next(0, 256)))
            };
            cnvElipses.Children.Add(elipse);
            Canvas.SetLeft(elipse, posicion.X);
            Canvas.SetTop(elipse, posicion.Y);
            DoubleAnimation animacion = new DoubleAnimation
            {
                To = cnvElipses.ActualHeight - elipse.Height,
                BeginTime = TimeSpan.FromSeconds(0),
                Duration = TimeSpan.FromSeconds(2),
                EasingFunction = new BounceEase
                {
                    Bounces=5,
                    EasingMode=EasingMode.EaseOut
                }
            };
            elipse.BeginAnimation(Canvas.TopProperty, animacion);

        }

        private void cnvElipses_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (elipse != null)
            {
                if (e.HeightChanged && cnvElipses.ActualHeight > e.PreviousSize.Height)
                {
                    DoubleAnimation animacion = new DoubleAnimation
                    {
                        To = cnvElipses.ActualHeight - elipse.Height,
                        BeginTime = TimeSpan.FromSeconds(0),
                        Duration = TimeSpan.FromSeconds(2),
                        EasingFunction = new BounceEase
                        {
                            Bounces = 5,
                            EasingMode = EasingMode.EaseOut
                        }
                    };
                    foreach (var item in cnvElipses.Children)
                    {
                        if (item is Ellipse)
                        {
                            ((Ellipse)item).BeginAnimation(Canvas.TopProperty, animacion);
                        }
                    }
                }
                else if (e.HeightChanged && cnvElipses.ActualHeight < e.PreviousSize.Height)
                {
                    DoubleAnimation animacion = new DoubleAnimation
                    {
                        To = cnvElipses.ActualHeight -elipse.Height,
                        BeginTime = TimeSpan.FromSeconds(0),
                        Duration = TimeSpan.FromSeconds(0.01),
                        EasingFunction = new BounceEase
                        {
                            Bounces = 5,
                            EasingMode = EasingMode.EaseOut
                        }
                    };
                    foreach (var item in cnvElipses.Children)
                    {
                        if (item is Ellipse)
                        {
                            ((Ellipse)item).BeginAnimation(Canvas.TopProperty, animacion);
                        }
                    }
                }
                else if(e.WidthChanged && cnvElipses.ActualWidth < e.PreviousSize.Width)
                {
                    
                    DoubleAnimation animacion = new DoubleAnimation
                    {
                        To = cnvElipses.ActualWidth - elipse.Width,
                        BeginTime = TimeSpan.FromSeconds(0),
                        Duration = TimeSpan.FromSeconds(2),
                        EasingFunction = new BounceEase
                        {
                            Bounces = 5,
                            EasingMode = EasingMode.EaseOut
                        }
                    };
                    foreach (var item in cnvElipses.Children)
                    {
                        
                        if (item is Ellipse)
                        {
                            ((Ellipse)item).BeginAnimation(Canvas.TopProperty, animacion);

                        }
                    }
                    
                }
            }
            
        }
    }
}
