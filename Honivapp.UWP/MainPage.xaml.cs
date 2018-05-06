using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Honivapp.UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void txtHonLiq_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtHonLiq.FocusState == FocusState.Unfocused)
            {                
            } else
            {
                try
                {
                    bool isNumber = false;
                    string newWord = txtHonLiq.Text.Replace(".", "");

                    try
                    {
                        long v = Int64.Parse(newWord);
                        isNumber = true;
                    } catch
                    {
                        isNumber = false;
                    }

                    if (isNumber)
                    {
                        double vLiquido = Math.Round((Double.Parse(txtHonLiq.Text.Replace(".", ""))), 0);

                        double vBruto = Math.Round((Int64.Parse(txtHonLiq.Text.Replace(".", "")) / 0.90), 0);
                        txtHonBruto.Text = vBruto.ToString("#,##0.##");

                        txtHonLiq.Text = vLiquido.ToString("#,##0.##");
                        txtHonLiq.SelectionStart = txtHonLiq.Text.Length;
                    } else
                    {
                        txtHonLiq.Text = txtHonLiq.Text.Remove(txtHonLiq.Text.Length - 1);
                    }

                }
                catch
                {
                    txtHonBruto.Text = "";
                }
            }
        }

        private void txtHonBruto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtHonBruto.FocusState == FocusState.Unfocused)
            {
            } else
            {
                try
                {
                    bool isNumber = false;
                    string newWord = txtHonBruto.Text.Replace(".", "");

                    try
                    {
                        long v = Int64.Parse(newWord);
                        isNumber = true;
                    }
                    catch
                    {
                        isNumber = false;
                    }

                    
                    if (isNumber)
                    {
                        double vBruto = Math.Round((Double.Parse(txtHonBruto.Text.Replace(".", ""))), 0);

                        double vLiquido = Math.Round((Int64.Parse(txtHonBruto.Text.Replace(".", "")) - (Int64.Parse(txtHonBruto.Text.Replace(".", "")) * 0.1)), 0);
                        txtHonLiq.Text = vLiquido.ToString("#,##0.##");

                        txtHonBruto.Text = vBruto.ToString("#,##0.##");
                        txtHonBruto.SelectionStart = txtHonBruto.Text.Length;
                    } else
                    {
                        txtHonBruto.Text = txtHonBruto.Text.Remove(txtHonBruto.Text.Length - 1);
                    }

                }
                catch
                {
                    txtHonLiq.Text = "";
                }
            }
        }

        /// <summary>
        /// Limpia los campos de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txtHonLiq.Text = "";
            txtHonBruto.Text = "";
            txtIvaLiq.Text = "";
            txtIvaBruto.Text = "";
            lblIvaVal.Text = "";
        }

        private void txtIvaLiq_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtIvaLiq.FocusState == FocusState.Unfocused)
            {
            }
            else
            {
                try
                {
                    bool isNumber = false;
                    string newWord = txtIvaLiq.Text.Replace(".", "");

                    try
                    {
                        long v = Int64.Parse(newWord);
                        isNumber = true;
                    }
                    catch
                    {
                        isNumber = false;
                    }

                    if (isNumber)
                    {
                        double vLiquido = Math.Round((Double.Parse(txtIvaLiq.Text.Replace(".", ""))), 0);

                        double vIva = Math.Round((Int64.Parse(txtIvaLiq.Text.Replace(".", "")) * 0.19), 0);
                        lblIvaVal.Text = vIva.ToString("#,##0.##");

                        double vBruto = Math.Round(vLiquido + vIva);
                        txtIvaBruto.Text = vBruto.ToString("#,##0.##");

                        txtIvaLiq.Text = vLiquido.ToString("#,##0.##");
                        txtIvaLiq.SelectionStart = txtIvaLiq.Text.Length;
                    }
                    else
                    {
                        txtIvaLiq.Text = txtIvaLiq.Text.Remove(txtIvaLiq.Text.Length - 1);
                    }

                }
                catch
                {
                    txtIvaBruto.Text = "";
                    lblIvaVal.Text = "";
                }
            }
        }

        private void txtIvaBruto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtIvaBruto.FocusState == FocusState.Unfocused)
            {
            }
            else
            {
                try
                {
                    bool isNumber = false;
                    string newWord = txtIvaBruto.Text.Replace(".", "");

                    try
                    {
                        long v = Int64.Parse(newWord);
                        isNumber = true;
                    }
                    catch
                    {
                        isNumber = false;
                    }


                    if (isNumber)
                    {
                        double vBruto = Math.Round((Double.Parse(txtIvaBruto.Text.Replace(".", ""))), 0);

                        double vLiquido = Math.Round((Int64.Parse(txtIvaBruto.Text.Replace(".", ""))) / 1.19, 0);
                        txtIvaLiq.Text = vLiquido.ToString("#,##0.##");

                        double vIva = Math.Round((vLiquido * 0.19), 0);
                        lblIvaVal.Text = vIva.ToString("#,##0.##");

                        txtIvaBruto.Text = vBruto.ToString("#,##0.##");
                        txtIvaBruto.SelectionStart = txtIvaBruto.Text.Length;
                    }
                    else
                    {
                        txtIvaBruto.Text = txtIvaBruto.Text.Remove(txtIvaBruto.Text.Length - 1);
                    }

                }
                catch
                {
                    txtIvaLiq.Text = "";
                    lblIvaVal.Text = "";
                }
            }
        }
    }
}
