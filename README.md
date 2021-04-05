# Base Template Vuexy Netcore 2.2

## Configuration

1. Buat file `config.json` pada directory `C:\Users\[LoginName]\application-name`, kemudian copy code configurasi dibawah ini 
```
{
  "CredentialFilePath" : "\\application-name\\token.json",
  "OauthApi" : {
    "Url" : "https://servername-gc.bfi.co.id/oauth/",
    "ApiKeyName":"xxx",
    "ApiKeyValue":"xxx"
  },
  "LegacyApi" : {
    "Url" : "https://servername.bfi.co.id/legacy_api/",
    "ApiKeyName":"xxx",
    "ApiKeyValue":"xxx"
  },
}
```
2. Copy ke `inetpub\wwwroot\folder_app` folder app bisa disesuaikan dengan nama aplikasinya
3. Buka IIS Manager kemudian klik kanan pada folder application pilih Convert to Aplication, pada pilihan selanjutnya pilih no manage code.
4. Buka `appsetting.json` kemudian ubah `BaseUrl` dan setting `GoogleAnalytic` Account seperti contoh dibawah ini :

``` 
"AppInfo": {
    "Author": "xxx",
    "ApplicationName": "Panel Dashboard BFI Finance Indonesia",
    "Keyword": "BFI Finance,butuh dana cepat, jaminan sertifikat rumah, pinjaman dana cepat, jaminan bpkb mobil, kredit mobil bekas, jaminan bpkb motor, gadai bpkb, simulasi kredit",
    "Description": "Aplikasi Dashboard untuk partner dari PT BFI Finance Indonesia Tbk.",
    "ApplicationVersion": "1.0.0"
  },
  "AppConfig": {
    "BaseUrl": "https://localhost:44388",
    "GoogleAnalytic": "UA-XXXXXXXXX-X",
    "reCAPTCHA": "UA-XXXXXXXXX-X"
  },

```
5. Folder `Docs` tidak masuk kedalam project, jadi lebih baik folder tersebut dihapus dan tidak masuk kedalam git.

> Notes :  Konfigurasi akan berbeda tergantung dari environment

## Changes Log
1. Initial Project.

## Tools

* ASP Net Core 2.2
* Bootstrap v4.3.1

