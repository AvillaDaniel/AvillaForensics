![logo avilla 800](https://user-images.githubusercontent.com/102838167/161397689-5df01560-546c-4d82-94a6-e4a3b677875f.png)

# Avilla Forensics 3.0 (Soon translated version into English)

# ⭐️ Project description

- Free Mobile Forensics Tool that allows you to: 

1.	Backup ADB.
2.	APK Downgrade in 15 Apps: WhatsApp (com.whatsapp), Telegram (org.telegram.messenger), Messenger (com.facebook.orca), ICQ (com.icq.mobile.client), Twitter (com.twitter.android), Instagram (com.instagram.android), Signal (org.thoughtcrime.securems), Linkdin (com.linkedin.android), Tiktok (com.zhiliaoapp.musically), Snapchat (com.snapchat.android), Tinder (com.tinder), Badoo (com.badoo.mobile), Mozilla Firefox (org.mozilla.firefox), Dropbox (com.drobox.android), Alibaba (com.alibaba.intl.android.apps.poseidon)).
3.	Parser Chats WhatsApp.
4. Miscellaneous ADB collections: (System Properties (Full), Dumpsys (Full), Disktats (Disk Information), Android Geolocation Dump (Location Manager State), IMEI (01 ,02), S/N (Serial Number), Processes, TCP (Active Internet connections), Accounts (UserInfo), DUMP Wifi, DUMP Detailed Wifi, CPU Information, Memory Information, Display Information (WINDOW MANAGER DISPLAY CONTENTS), Resources, Resolution (Physical size), Screen Dump (.XML file), Dump Backup (Backup Manager is enabled), List Installed Third-Party Applications, List Native System Applications, Contacts, SMS, System Events, Active Users, Android Version, DB Info (Applications Database Info), On/Off History, LogCat, Space In Use Information, Carrier, Bluetooth (Bluetooth Status), Image File Location, Audio File Location, Video File Location, Face Recognition DUMP, Global Settings, Security Settings a, System Settings, Remove/Add PIN (Requires current PIN), DUMP ADB (ADB Connections), Reboot, Reboot Recovery Mode, Reboot Bootloader Mode, Reboot Fastboot Mode.
5. Tracking, Downloading and Decryption of Whatsapp .ENC files.
6. Contact List Search.
7. Deleted WhatsApp Photos Avatars and Contacts.
8. Decrypting WhatsApp Databases.
9. Screenshots.
10. Screen DUMP.
11. Chat Capture.
12. Automatic integration with IPED.
13. Automatic integration with AFLogical.
14. Automatic integration with Alias ​​Connector.
15. Conversion from .AB to .TAR.
16. Fast Scan and Real-time Transfer .
17. Image Finder (Hash, Metadata, Geolocation, Plotting the location on Google Maps and Google Earch).
18. Plotting (IN BATCHES) of the Geolocation of images on Google Earch (geo.kml) with patch and thumbnails of the images.
19. Installing and Uninstalling APKs via ADB.
20. HASH Calculator.
21. Android Folder Browser (PULL and PUSH).
22. Device Mirroring.
23. Instagram Data Scraping.
24. Automatic integration with MVT-1.5.3.
25. Access Through the Tool to JADX.
26. Access Through the Tool to WhatsApp Viewer.
27. Access Through the Tool to the BCV.
28. Access Through the Tool to SQLStudio.
29. PRUNE GPS Tool Access.

![2022-04-16](https://user-images.githubusercontent.com/102838167/163805274-3a8d13e6-2201-4527-8eb4-333068811e14.png)

## 🕵️ Functionalities

### 🤖 Backup ADB
- Android default backup.
  
### 📱 APK Downgrade in 15 Applications (Access to root files without the need for ROOT)

![APKS](https://user-images.githubusercontent.com/102838167/161399527-040d0624-f034-4d07-b8f0-494fb31e26d8.PNG)
      
- WhatsApp (com.whatsapp)
- Telegram (org.telegram.messenger)
- Messenger (com.facebook.orca)
- ICQ (com.icq.mobile.client)
- Twitter (com.twitter.android)
- Instagram (com.instagram.android)
- Signal (org.thoughtcrime.securems)
- Linkdin (com.linkedin.android)
- Tiktok (com.zhiliaoapp.musically)
- Snapchat (com.snapchat.android)
- Tinder (com.tinder)
- Badoo (com.badoo.mobile)
- Mozilla Firefox (org.mozilla.firefox)
- Dropbox (com.drobox.android) 
- Alibaba (com.alibaba.intl.android.apps.poseidon) 

- Examples:

![2022-04-02](https://user-images.githubusercontent.com/102838167/161398236-c20a9bd3-499d-49fc-b862-1694b369b334.png)

![Screenshot_20210621-140950](https://user-images.githubusercontent.com/102838167/161463461-c402a208-324f-42c5-a1c2-9f15852731be.png)

![whats](https://user-images.githubusercontent.com/102838167/161398968-0e8fe0a7-5573-4b8e-9e00-450ce7f9e677.PNG)
  
![files-whats](https://user-images.githubusercontent.com/102838167/161401049-7402a3bd-06a2-48d8-9629-d0d93a61982a.PNG)

### 📱 Caution

![atencao](https://user-images.githubusercontent.com/102838167/173718670-c863f680-b356-4ea6-af10-2376783d9cee.png)

- The Backup Downgrade procedure in ANDROID 12 can damage the database

### 🛠 DOWNGRADE APK Test
- The tool does a test in a generic application (**com.aplicacaoteste.apk**) before starting the DOWNGRADE process in the target APP.
- Tips: **XIAOMI** phones may come with USB protections, remove these protections **without taking the device out of airplane mode** by following the steps below:
1. Enable developer options.
2. Settings -> Additional Settings -> **Disable MIUI optimizations**
3. Reset phone
4. Settings -> Additional Settings -> Developer Options -> **Allow USB Debugging**
5. Security (system app) -> Manage apps -> Permissions -> Gear icon (top right) -> **Install via USB (true)**
6. Reset phone
7. Settings -> Additional Settings -> Developer Options -> **Enable USB Installation**    

### 💬 (NEW) Parser Chats WhatsApp from NEW Database SCHEME

1. Select the Chats destination folder (Copy the **"Media"** folder in this same location).
2. Select the folder: **\com.whatsapp\f\Avatars**
3. Select the .DB file: **\com.whatsapp\db\msgstore.db**

New Schema (Table: **message**)
_id
chat_row_id
from_me
key_id
sender_jid_row_id
status,broadcast
recipient_count
participant_hash
origination_flags
origin
timestamp
received_timestamp
receipt_server_timestamp
message_type
text_data (Mensagens)
starred
lookup_tables
message_add_on_flags
sort_id


![2022-04-17 (5)](https://user-images.githubusercontent.com/102838167/163806359-d86b2de8-9aeb-4bdb-a1f6-198b7563317b.png)

![2022-04-17 (8)](https://user-images.githubusercontent.com/102838167/163806376-9dd34207-d3d8-466a-82c0-e676f0fdf85f.png)

![chats](https://user-images.githubusercontent.com/102838167/163806409-d6efa011-9d9a-4675-a01c-15f570a105fb.png)

### 💬 (NEW) Parser Chats WhatsApp from previous database schema

1. Select the Chats destination folder (Copy the "Media" folder in this same location).
2. Select the folder: **\com.whatsapp\f\Avatars**
3. Select the .DB file: **\com.whatsapp\db\msgstore.db**

Old Schema (Table: **messages**)

_id
key_remote_jid
key_from_me
key_id
status
needs_push
data (Mensagens)
timestamp
media_url
media_mime_type
media_wa_type
media_size
media_name
media_caption
media_hash
media_durationorigin
latitude
longitude
thumb_image
remote_resource
received_timestamp
send_timestamp
receipt_server_timestamp
receipt_device_timestamp
read_device_timestamp
played_device_timestamp
raw_data
recipient_count
participant_hash
starred
quoted_row_id
mentioned_jids
multicast_id
edit_version
media_enc_hash
payment_transaction_id
forwarded
preview_type
send_count
lookup_tables
future_message_type
message_add_on_flags

![2022-04-17](https://user-images.githubusercontent.com/102838167/163806680-08ae4135-d180-48f5-8c3e-99fc83a86a34.png)

![2022-04-17 (4)](https://user-images.githubusercontent.com/102838167/163806716-e2f002d0-45ec-42e8-be20-fdd8ace00129.png)

### 📱 Miscellaneous ADB collections in .TXT format
- System Properties (Full).
- Dumpsys (Complete).
- Disktats (Disk information).
- Android Geolocation Dump (Location Manager State).
- IMEI (01 .02).
- Y/N (Serial Number).
- Law Suit.
- TCP (Active Internet connections).
- Accounts (UserInfo).
- DUMP Wifi.
- Detailed Wifi DUMP.
- CPU information.
- Memory Information.
- Display Information (WINDOW MANAGER DISPLAY CONTENTS).
- Resources.
- Resolution (Physical size).
- Screen Dump (.XML file).
- Dump Backup (Backup Manager is enabled).
- List Installed Third-Party Applications.
- List Native System Applications.
- Contacts.
- SMS.
- System Events.
- Active Users.
- Android version.
- DB Info (Applications Database Info).
- On/Off History.
- LogCat.
- Space in Use Information.
- Operator.
- Bluetooth (Bluetooth Status).
- Location of Image Files.
- Location of Audio Files.
- Location of Video Files.
- Face Recognition DUMP
- Global Settings.
- Security Settings.
- System Settings.
- Remove/Add PIN (Requires current PIN).
- DUMP ADB (Connections ADB).
- Reboot.
- Reboot Recovery Mode.
- Reboot Bootloader Mode.
- Reboot Fastboot Mode.

![2022-04-03 (4)](https://user-images.githubusercontent.com/102838167/161448699-9b8b82ed-95cd-472d-96b2-bcf8cf059f56.png)

- Examples:
- Dump ADB: ADB.txt, in this example we can check the last computer connected via ADB with the device:

![ADBc](https://user-images.githubusercontent.com/102838167/162361557-dbcb5537-e14d-4621-9262-7be0223e18d9.PNG)

- Dumpsys: dumpsys.txt, in addition to bringing thousands of device information, in this example we can check the uninstall date of an application:

![delete](https://user-images.githubusercontent.com/102838167/162439594-cdf58b1d-10d8-4964-a29b-bb0bf7e5b4a2.PNG)

- Note: The information can be in Unix Timestamp time format, use the link below to convert:
- 1649374898421 (Unix Timestamp) = Thu Apr 07 2022 23:41:38 GMT+0000 (GMT)
- 
- https://www.unixtimestamp.com/

### ⚡️ (NEW) Tracking, Downloading and Decrypting Whatsapp .ENC Files

![2022-04-10](https://user-images.githubusercontent.com/102838167/163823905-47262d30-d4c2-4a69-957a-80a765372247.png)
- Generate the Script and run the generated **.bat** file.

"C:\Forensics\bin\whatsapp-media-decrypt\decrypt.py"

### ⚡️ (NEW) Contact List Search, Avatar Photos and Deleted WhatsApp Contacts

1. Select the folder: **\com.whatsapp\f\Avatars**
2. Select .DB file: **\com.whatsapp\db\wa.db**

![contatos](https://user-images.githubusercontent.com/102838167/163809831-53167b37-2da5-43d0-96dd-9b596f1d2191.PNG)

### 📐 WhatsApp Database Decryption
- Crypt12.
- Crypt14.

### 📸 Screenshots, Screen DUMP and Chat Capture. 

![2022-04-03 (1)](https://user-images.githubusercontent.com/102838167/161448487-b4dea9e4-9293-4b65-8981-1de07caf7288.png)

![2022-04-03 (2)](https://user-images.githubusercontent.com/102838167/161448491-d9622700-c41e-41b0-8442-a055def05913.png)

### 🚀 Automatic integration with IPED.
- Indexing of folders, .zip, .tar, .dd, .ufdr.

![2022-04-03 (3)](https://user-images.githubusercontent.com/102838167/161448593-ba22fdde-f6ce-4dff-b065-9b1d5a177b63.png)

![2022-04-03 (11)](https://user-images.githubusercontent.com/102838167/161464428-226fe8f1-bebe-4d34-96af-95c7e0cff533.png)

### 🚀 Automatic integration with AFLogical OSE 1.5.2.

- Performs the acquisition automatically without user intervention.
- "C:\Forensics\bin\AFLogicalOSE152OSE.apk"

![af](https://user-images.githubusercontent.com/102838167/161461445-74dc290d-7ba7-4369-8248-a796f7299c19.PNG)

### 🚀 Automatic integration with Alias Connector
- Performs the acquisition automatically without user intervention.
- "C:\Forensics\bin\com.alias.connector.apk"

![alias](https://user-images.githubusercontent.com/102838167/161463618-61745835-59f8-4d37-9512-f714dbc6effc.PNG)

### 📐 Conversion from .AB to .TAR
- Passworded ADB backups may take longer to convert.
- Try not to put passwords in the backups requested in "ADB Backup" or "Downgrade", so you speed up the conversion process.
- If this module doesn't work, try to add the **"C:\Forensics"** patch to the system variables

![variaveis](https://user-images.githubusercontent.com/102838167/161451033-a41c46a0-35cb-4c3b-9aa3-cafee9c92284.PNG)

### ♻ Fast Scan and Real-time Transfer
- Images: .jpg, .jpeg, .png, .psd, .nef, .tiff, .bmp, .tec, .tif, .webp
- Videos: .aaf, .3gp, .asf, .avi, .m1v, .m2v, .m4v, .mp4, .mov, .mpeg, .mpg, .mpe, .mp4, .rm, .wmv, .mpv , .flv, .swf
- Audios: .opus, .aiff, .aif, .flac, .wav, .m4a, .ape, .wma, .mp2, .mp1, .mp3, .aac, .mp4, .m4p, .m1a, .m2a , .m4r, .mpa, .m3u, .mid, .midi, .ogg
- Archives: .zip, .rar, .7zip, .7z, .arj, .tar, .gzip, .bzip, .bzip2, .cab, .jar, .cpio, .ar, .gz, .tgz, .bz2
- Databases: .db, .db3, .sqlite, .sqlite3, .backup (SIGNAL)
- Documents: .htm, .html, .doc, .docx, .odt, .xls, .xlsx, .ppt, .pptx, .pdf, .txt, .rtf
- Executables: .exe, .msi, .cmd, .com, .bat, .reg, .scr, .dll, .ini, .apk
- 
![2022-04-03 (5)](https://user-images.githubusercontent.com/102838167/161448785-6c0b41a0-3fa3-448c-bcf9-5836e92632c1.png)

### 🔠  Image Finder (Hash, Metadata, Geolocation, Plot location on Google Maps and Google Earch)

- Note: For this module DO NOT save your acquisitions on the Desktop, save for example in "C:\folder_name\collection_01" to run the image search.

![2022-03-31 (2)](https://user-images.githubusercontent.com/102838167/161401187-e5c5f707-1601-4e17-8007-49931a6c1784.png)

![2022-03-31 (3)](https://user-images.githubusercontent.com/102838167/161401191-49f18d65-61a3-49a9-a7b4-ba580fddc319.png)

https://user-images.githubusercontent.com/102838167/161446333-ddcbe368-7b03-4090-b10c-5cd6f32ad023.mp4

### 📜 (NEW) Plot (BATCH) of Geolocation of images on Google Earch (geo.kml) with patch and thumbnails of images.

- Note: To plot the thumbnails along with the yellow points, download **Google Earch Pro**, if you plot on Google Earch Online, only the blue points will be plotted without the images.
- Click on **GENERATE KML** to batch generate the **geo.kml** file

![geo](https://user-images.githubusercontent.com/102838167/163811621-3a1c69f3-f74f-4488-a943-c866903a0341.PNG)

![2022-04-06](https://user-images.githubusercontent.com/102838167/163807399-c8de39b5-f8a1-4632-9d77-ba19ca2cd354.png)

![2022-04-10 (6)](https://user-images.githubusercontent.com/102838167/163807446-07ec29a1-7393-4d98-9a47-7de8cf4a31ab.png)

![2022-04-10 (8)](https://user-images.githubusercontent.com/102838167/163808357-38af47df-141c-400f-b848-634a7ef06ca3.png)

![2022-04-10 (9)](https://user-images.githubusercontent.com/102838167/163808370-955743bd-bec6-483a-a8e2-e6e0b3349fca.png)

### 🛠 Installing and Uninstalling APKs via ADB
- .APK files

### ⏳ HASH Calculator
- Note: For this module DO NOT save your acquisitions on the Desktop, save for example in "C:\folder_name\collection_02" to calculate the Hashs of the files.
- Calculates the Hash of all files in an acquisition.
- SHA-256.
- SHA-1.
- SHA-384.
- SHA-512.
- SHA-MD5.

![2022-03-28 (9)](https://user-images.githubusercontent.com/102838167/161402185-07ef2510-735f-4940-b56a-a7624e42f711.png)

### 📱 (NOVO) Navegador de Pastas Android (PULL e PUSH)

- Um Simples navegador de pastas para realizar o PULL e o PUSH de arquivos ou pastas.

![2022-04-10 (1)](https://user-images.githubusercontent.com/102838167/163810052-a45ec6cc-8e92-4ff7-bfcd-b6da09e44a31.png)

### 🎥 Espelhamento do Dispositivo
- "C:\Forensics\bin\scrcpy"

![espeçhamento](https://user-images.githubusercontent.com/102838167/161463105-71285aa7-715c-450f-b259-c40c00b3a0a7.PNG)

### 🚀 Raspagem de dados Instagram

![2022-04-03 (7)](https://user-images.githubusercontent.com/102838167/161449129-c23ca774-f268-49ac-b7cf-30b1a305d4e5.png)

### 🚀 Integração automática com o MVT-1.5.3
- "C:\Forensics\bin\mvt-1.5.3\mvt.bat"

![mvt](https://user-images.githubusercontent.com/102838167/161465986-08013fb5-d5b3-468f-bab2-a9f018904524.PNG)

### 🚀 Acesso Através da Ferramenta ao JADX (Dex to Java Decompiler)
- "C:\Forensics\bin\jadx-1.2.0\jadx-gui-1.2.0-no-jre-win.exe"

### 🚀 Acesso Através da Ferramenta ao WhatsApp Viewer
- "C:\Forensics\bin\WhatsAppViewer.exe"

### 🚀 Acesso Através da Ferramenta ao BCV (Byte Code Viewer)
- "C:\Forensics\bin\bycodeviewer\GUI-ByteCode.bat"

### 🚀 Acesso Através da Ferramenta ao SQLStudio
- "C:\Forensics\bin\SQLiteStudio\SQLiteStudio.exe"

### 🚀 Acesso Através da Ferramenta ao GPS PRUNE
- "C:\Forensics\bin\gpsprune\GUI-GPSPrune.bat"

## ⚙️ Pré-requisitos da Ferramenta
- Conhecimentos TÉCNICOS de Forense em Dispositívos Móveis.
- Dispositivo com modo DEPURAÇÂO ativado.
- Windows 10/11 com suas devidas atualizações.

## ⚙️ Pré-requisitos Ferramentas de Terceiros: 
- JAVA (https://www.java.com/pt-BR/).
- PHYTON (https://www.python.org/).

## 📋 Treinamentos
![Banner sympla Extração Lógica Avançada com Avilla Forensics](https://user-images.githubusercontent.com/102838167/161400433-dd4cce07-161f-44b7-b506-378841ac64b4.png)

- ACADEMIA DE FORENSE DIGITAL - AFD (Extração Avançada com Avilla Forensics).
- https://academiadeforensedigital.com.br/
- Sobre o curso: https://academiadeforensedigital.com.br/treinamentos/extracao-logica-avancada-com-avilla-forensics/
- Link curso: https://pay2.provi.com.br/checkout/academia-de-forense-digital?courses=%5B33759%5D
- Conteúdo do Curso: https://drive.google.com/file/d/1mARPeClW1o3EBNIcLh3i9YzBn_fGuSet/view
- Webinar: [![Youtube Badge](https://img.shields.io/badge/-YouTube-ff0000?style=flat-square&labelColor=ff0000&logo=youtube&logoColor=white&link=https://www.youtube.com/watch?v=zQigjIIkBjQ)](https://www.youtube.com/watch?v=zQigjIIkBjQ) 
- Manual e vídeo passo a passo elaborado pelo Policial Civil Emerson Borges - PC MG: 
- https://youtu.be/KuSmct1Qa30
- [MANUAL_EXTRACAO_AVILLA_FORENSICS.pdf](https://github.com/AvillaDaniel/AvillaForensics/files/8411988/MANUAL_EXTRACAO_AVILLA_FORENSICS.pdf)

## 💻 Instalação Avilla Forensics 3.0 
- Ferramenta autoexecutável, não requer instalação.
- Execute como administrador o arquivo "Avilla_Forensics.exe".
- Execute a ferramenta a partir do "C:\".
- Exemplo: C:\Forensics".
- Não coloque espaços no nome da pasta da ferramenta.

## 💻 Instalação Ferramentas de Terceiros
### Requer JAVA (https://www.java.com/pt-BR/):
- IPED-3.18.12 "C:\Forensics\IPED-3.18.12_and_plugins" (Apenas instalar o JAVA).
- Bycode Viewer: "C:\Forensics\bin\bycodeviewer" (Apenas instalar o JAVA).
- Jadx-1.2.0: "C:\Forensics\bin\jadx-1.2.0" (Apenas instalar o JAVA).
- Backup Extractor: "C:\Forensics\backup_extractor" (Apenas instalar o JAVA).
- O módulo Backup Extrator (.AB para .TAR) pode exigir que vc adicione o patch "C:\Forensics" nas variáveis do sistema.
- GPS PRUNE "C:\Forensics\bin\gpsprune" (Apenas instalar o JAVA)..

### Requer PHYTON (https://www.python.org/):
- Instaloader: Para instalar execute o arquivo "C:\Forensics\bin\instaloader-master\install_instaloader.bat" ou:

```pip install instaloader```

- MVT-1.5.3: Para instalar execute o arquivo "C:\Forensics\bin\mvt-1.5.3\install_mvt.bat" ou:

```pip install mvt```

- Whacipher: Para instalar execute o arquivo "C:\Forensics\bin\install_whacipher.bat" ou:

```pip install --upgrade -r requirements.txt```  

- Whatsapp Media Decrypt: Para instalar execute o arquivo "C:\Forensics\bin\install_wmd.bat" ou:

```pip install pycryptodome```  

## 🌐 Download

### (NOVO) v1_0_0_177 - 02/05/2022 (980 MB) 
- https://www.avillaforensics.com.br/forensics.zip
- MD5: A24D7F943FB6D2EFD67C0C517383B915
- SHA1: 913FDD2D5392BB9FF2487521843C4A2CF13CC59B
- SHA256: AC02FE209C19F1D1C01BEB8E457A148E7C7820D3D5C1AB882FDB30F7DBA54E8F
- SHA384: E8249466558B17CA365F8860CE839B3BF76F5F0FB67AE15CCB7DC3AF5B04C53FF5A070A7A6372475CBDD788F0237CD68
- SHA512: B8CB81A365FBE3A962F71AE2986C683B4CA12AA8CAC5313E419DC11CCB9DB06B141022E1D06E13AC00690FC72D3C390110146F6A8BA

## ⚙️ Tecnologias utilizadas
- C#.
- Python.
- Java.

## 🚀 Licença
- Software Gratuito.

## 🤖 Contatos
- [![Linkedin Badge](https://img.shields.io/badge/-LinkedIn-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/daniel-a-avilla-0987/)](https://www.linkedin.com/in/daniel-a-avilla-0987/)
- https://www.linkedin.com/in/daniel-a-avilla-0987/
- daniel.avilla@policiacivil.sp.gov.br

## 📱  Ferramentas de terceiros inclusas no pacote
- IPED-3.18.14: https://github.com/sepinf-inc/IPED (Requer Java).
- Bytecode Viewer: https://github.com/phith0n/bytecode-viewer (Requer Java).
- Jadx-1.2.0: https://github.com/skylot/jadx (Requer Java). 
- Android Backup Extractor: https://github.com/nelenkov/android-backup-extractor (Requer Java).
- GPS PRUNE: https://activityworkshop.net/software/gpsprune/download.html (Requer Java).

- Instaloader: https://github.com/instaloader/instaloader (Requer Python).
- MVT-1.5.3: https://github.com/mvt-project/mvt (Requer Python).
- Whatsapp Encryption and Decryption: https://github.com/B16f00t/whapa (Requer Python).
- Whatsapp-media-decrypt: https://github.com/sh4dowb/whatsapp-media-decrypt (Requer Python).

- Screen Copy: https://github.com/Genymobile/scrcpy
- AFLogical OSE 1.5.2: https://github.com/nowsecure/android-forensics
- Exiftool: https://github.com/exiftool/exiftool
- Grep: https://git-scm.com/docs/git-grep
- Alias Connector: http://www.newseg.seg.br/newseg/
- SqlStudio: https://sqlitestudio.pl/

## 😎 Agradecimentos

![LogoGrandecopy](https://user-images.githubusercontent.com/102838167/161445299-a5d6a50f-e2de-440d-bcbc-d364a365e64d.png)

