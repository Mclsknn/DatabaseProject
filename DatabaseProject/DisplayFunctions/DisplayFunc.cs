using DatabaseProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.DisplayFunctions
{
    public static class DisplayFunc
    {
        public static int DisplayStartMenu()
        {
            Console.WriteLine("Hangi tablo üzerinde işlem yapmak istiyorsunuz ? \n");
            Console.WriteLine("1 -> DeliveryDetail\n" + "2 -> Country\n" + "3 -> City\n" + "4 -> LoadDetail\n" + "5 -> Driver\n" + "6 -> Car\n" + "7 -> TyreDetail\n");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int DisplayEndMenu()
        {
            Console.WriteLine("Hangi işlemi yapmak istiyorsunuz ?\n");
            Console.WriteLine("1 -> Ekleme\n" + "2 -> Silme\n" + "3 -> Güncelleme");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int DisplayDelete()
        {
            Console.WriteLine("Silinmesi istediğiniz değerin id'sini giriniz ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int DisplayUpdate()
        {
            Console.WriteLine("Güncellenmesi istediğiniz değerin id'sini seçiniz ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static void IsSuccess()
        {
            Console.WriteLine("İşlem başarılı");
        }

        public static void IsError()
        {
            Console.WriteLine("Bir sorunla karşılaşıldı");
        }
    }
}
