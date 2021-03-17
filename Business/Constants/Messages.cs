using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarsListed = "Arabalar listelendi";
        public static string CarAdded = "Araba eklendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";

        public static string BrandsListed = "Markalar listelendi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";

        public static string ColorsListed = "Renkler listelendi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorNameInvalid = "Renk ismi geçersiz";

        public static string CustomersListed = "Müşteriler listelendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerNameInvalid = "Müşteri ismi geçersiz";
        public static string CustomerDetailsListed="Müşteri detayları listelendi";

        public static string RentalsListed = "Kiralamaler listelendi";
        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalInvalid = "Araç önceden kiralanmış";

        public static string UsersListed = "Kullanıcıler listelendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz";


        public static string CarImageLimitExceed = "Arabaya ait 5 adet resim mevcut, bir araç için en fazla 5 resim ekleyebilirsiniz.";

        public static string CarImageLimitExceeded = "Bir araba için en fazla 5 resim eklenebilir.";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
