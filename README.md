# Base Template UI
## Configuration

1. Buat file `config.json` pada directory `C:\Users\[LoginName]\[application-name]`, kemudian copy code configurasi dibawah ini 
```
{
  "CredentialFilePath" : "\\application-name\\token.json",
  "OauthApi" : {
    "Url" : "https://servername.bfi.co.id/oauth/",
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
2. Ubah config `app-name` sesuai dengan nama applikasi pada file `nlog.config`
3. Buka `appsetting.json` kemudian ubah `BaseUrl` dan setting `GoogleAnalytic` Account seperti contoh dibawah ini :

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
4. Folder `Docs` tidak masuk kedalam project, jadi lebih baik folder tersebut **dihapus dan tidak masuk kedalam git**.
5. Setiap halaman yang memiliki lebih dari 1 file js harus dibundle seperti contoh dibawah ini :

```
<environment include="Development">
    <script src="~/js/pages/file-javascript-1.js"></script>
    <script src="~/js/pages/file-javascript-2.js"></script>
    <script src="~/js/pages/file-javascript-3.js"></script>
</environment>
<environment include="Production">
    <script src="~/js/dist/file-javascript.min.js"></script>
</environment>
```

kemudian update file `bundleconfig.json` seperti dibawah ini :

```
{
    "outputFileName": "wwwroot/dist/file-javascript.min.js",
    "inputFiles": [
      "wwwroot/js/pages/file-javascript-1.js",
      "wwwroot/js/pages/file-javascript-2.js",
      "wwwroot/js/pages/file-javascript-3.js",
    ]
  },
```
6. Untuk penambahan library **javascript** ataupun **css** harus melalui file `libman.json`
---
## Step Deploy
1. Copy ke `inetpub\wwwroot\folder_app` folder app bisa disesuaikan dengan nama aplikasinya
2. Buka IIS Manager kemudian klik kanan pada folder application pilih Convert to Aplication, pada pilihan selanjutnya pilih no manage code.
---
## Documentation

untuk dokumentasi silahkan klik [disini](http://rnd2.bfi.co.id/bfi-theme)


## Changes Log
1. Initial Project.

## Tools

* ASP Net Core 2.2
* Bootstrap v4.3.1

