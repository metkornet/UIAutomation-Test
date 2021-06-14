using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {

            AutomationElement desktopChildren = AutomationElement.RootElement.FindFirst(
                TreeScope.Children, new PropertyCondition
                (AutomationElement.NameProperty, "Подключение к myserver"));

            if (desktopChildren != null)
            {
                AutomationElement loginviewer = desktopChildren.FindFirst(
                TreeScope.Descendants, new PropertyCondition
                (AutomationElement.AutomationIdProperty, "1002"));

                // получение поля ввода логина

                AutomationElement loginfield = loginviewer.FindFirst(
               TreeScope.Descendants, new PropertyCondition
               (AutomationElement.ClassNameProperty, "Edit"));

                // получение поля ввода пароля

                AutomationElement pass = desktopChildren.FindFirst(
                TreeScope.Descendants, new PropertyCondition
                (AutomationElement.AutomationIdProperty, "1005"));

                // автоматизированный ввод

                object valuePattern = null;
                object valuePassword = null;

                System.Threading.Thread.Sleep(2000);

                if (!loginfield.TryGetCurrentPattern(ValuePattern.Pattern, out valuePattern)) { }
                else
                {
                    ((ValuePattern)valuePattern).SetValue("test");
                }


                if (!pass.TryGetCurrentPattern(
                    ValuePattern.Pattern, out valuePassword))
                { }
                else
                {
                    ((ValuePattern)valuePassword).SetValue("tesr");
                }

                // получение кнопки 
                AutomationElement buttonOk = desktopChildren.FindFirst(
                 TreeScope.Descendants, new PropertyCondition
                 (AutomationElement.AutomationIdProperty, "1"));
                System.Threading.Thread.Sleep(2000);
                // автоматическое закрытие 
                InvokePattern ivkp = buttonOk.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                ivkp.Invoke();
                Main();
            }
            else { Main(); }

        } 


    }

}
