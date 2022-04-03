![logo avilla 800](https://user-images.githubusercontent.com/102838167/161397689-5df01560-546c-4d82-94a6-e4a3b677875f.png)

# Avilla Forensics 3.0

# Descrição do Projeto
- Ferramenta livre e gratuita de Forense em dispositivos móveis.

## Funcionalidades

### Backup ADB
- Backup padrão do Android.
  
### APK  Downgrade em 15 Aplicativos (Acesso aos arquivos raizes sem a necessidade do ROOT)

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

![2022-04-02](https://user-images.githubusercontent.com/102838167/161398236-c20a9bd3-499d-49fc-b862-1694b369b334.png)

![whats](https://user-images.githubusercontent.com/102838167/161398968-0e8fe0a7-5573-4b8e-9e00-450ce7f9e677.PNG)
  
![files-whats](https://user-images.githubusercontent.com/102838167/161401049-7402a3bd-06a2-48d8-9629-d0d93a61982a.PNG)

### Coletas ADB diversas em formato .TXT
- Propriedades do Sistema (Completo).
- Dumpsys (Completo).
- Disktats (Informações de disco).
- Dump Geolocalização Android (Location Manager State).
- IMEI (01 ,02).
- S/N (Serial Number).
- Processos.
- TCP (Active Internet connections).
- Contas (UserInfo).
- DUMP Wifi.
- DUMP Wifi Detalhado.
- Informações de CPU.
- Informações de Memória.
- Informações de Display (WINDOW MANAGER DISPLAY CONTENTS).
- Recursos.
- Resolução (Physical size).
- Dump de Tela (Arquivo .XML).
- Dump Backup (Backup Manager is enabled).
- Lista Aplicativos de Terceiros Instalados.
- Lista Aplicativos Nativos do Sistema.
- Contatos.
- SMS.
- Eventos do Sistema.
- Usuários Ativos.
- Versão do Android.
- DB Info (Applications Database Info).
- Histórico Liga/Desliga.
- LogCat
- Informações de Espaço em Uso.
- Operadora
- Bluetooth (Bluetooth Status).
- Localização dos Arquivos de Imagem.
- Localização dos Arquivos de Áudios.
- Localização dos Arquivos de Vídeos.
- DUMP do Reconhecimento Facial
- Configurações Globais.
- Configurações de Segurança.
- Configurações do Sistema.
- Remover/Add PIN (Requer PIN atual).
- DUMP ADB (Conexões ADB).
- Reboot.
- Reboot Recovery Mode.
- Reboot Bootloader Mode.
- Reboot Fastboot Mode.

![2022-04-03 (4)](https://user-images.githubusercontent.com/102838167/161448699-9b8b82ed-95cd-472d-96b2-bcf8cf059f56.png)

### Decryptação Databases WhatsApp
- Crypt12.
- Crypt14.

### Capturas de Tela, DUMP de Tela e Chat Capture. 

![2022-04-03 (1)](https://user-images.githubusercontent.com/102838167/161448487-b4dea9e4-9293-4b65-8981-1de07caf7288.png)

![2022-04-03 (2)](https://user-images.githubusercontent.com/102838167/161448491-d9622700-c41e-41b0-8442-a055def05913.png)

### Integração automática com o IPED
- Indexação de pastas, .zip, .tar, .dd, .ufdr. 

![2022-04-03 (3)](https://user-images.githubusercontent.com/102838167/161448593-ba22fdde-f6ce-4dff-b065-9b1d5a177b63.png)

### Conversão de .AB para .TAR

### Varredura Rápida e Transferência em tempo real
- Imagens: .jpg, .jpeg, .png, .psd, .nef, .tiff, .bmp, .tec, .tif, .webp
- Videos: .aaf, .3gp, .asf, .avi, .m1v, .m2v, .m4v, .mp4, .mov, .mpeg, .mpg, .mpe, .mp4, .rm, .wmv, .mpv, .flv, .swf
- Audios: .opus, .aiff, .aif, .flac, .wav, .m4a, .ape, .wma, .mp2, .mp1, .mp3, .aac, .mp4, .m4p, .m1a, .m2a, .m4r, .mpa, .m3u, .mid, .midi, .ogg
- Arquivos: .zip, .rar, .7zip, .7z, .arj, .tar, .gzip, .bzip, .bzip2, .cab, .jar, .cpio, .ar, .gz, .tgz, .bz2
- Databases: .db, .db3, .sqlite, .sqlite3, .backup (SIGNAL)
- Documentos: .htm, .html, .doc, .docx, .odt, .xls, .xlsx, .ppt, .pptx, .pdf, .txt, .rtf
- Executaveis: .exe, .msi, .cmd, .com, .bat, .reg, .scr, .dll, .ini, .apk

![2022-04-03 (5)](https://user-images.githubusercontent.com/102838167/161448785-6c0b41a0-3fa3-448c-bcf9-5836e92632c1.png)

### Localizador de Imagens (Hashs, Metadados, Geolocalização, Plotagem da localização no Google Maps e Google Earch)

- Obs: Para este módulo NÃO salve suas aquisições na Área de Trabalho, salve por exemplo no "C:\nome_da_pasta\coleta_01" para assim rodar a busca das imagens.

![2022-03-31 (2)](https://user-images.githubusercontent.com/102838167/161401187-e5c5f707-1601-4e17-8007-49931a6c1784.png)

![2022-03-31 (3)](https://user-images.githubusercontent.com/102838167/161401191-49f18d65-61a3-49a9-a7b4-ba580fddc319.png)

https://user-images.githubusercontent.com/102838167/161446333-ddcbe368-7b03-4090-b10c-5cd6f32ad023.mp4

### Instalação e Desinstalação de APKs via ADB

### Calculadora HASH
- Obs: Para este módulo NÃO salve suas aquisições na Área de Trabalho, salve por exemplo no "C:\nome_da_pasta\coleta_02" para assim calcular as Hashs dos arquivos.
- Calcula as Hashs de todos os arquivos de uma aquisição.
- SHA-256.
- SHA-1.
- SHA-384.
- SHA-512.
- SHA-MD5.

![2022-03-28 (9)](https://user-images.githubusercontent.com/102838167/161402185-07ef2510-735f-4940-b56a-a7624e42f711.png)

### Raspagem de dados Instagram

![2022-04-03 (7)](https://user-images.githubusercontent.com/102838167/161449129-c23ca774-f268-49ac-b7cf-30b1a305d4e5.png)

### Acesso Através da Ferramenta ao JADX (Dex to Java Decompiler)

### Acesso Através da Ferramenta ao WhatsApp Viewer

### Acesso Através da Ferramenta ao BCV (Byte Code Viewer)

## Pré-requisitos da Ferramenta
- Conhecimentos TÉCNICOS de Forense em Dispositívos Móveis.
- Dispositivo com modo DEPURAÇÂO ativado.
- Windows 10/11 com suas devidas atualizações.

## Pré-requisitos Ferramentas de Terceiros: 
- JAVA (https://www.java.com/pt-BR/).
- PHYTON (https://www.python.org/).

## Treinamentos
![Banner sympla Extração Lógica Avançada com Avilla Forensics](https://user-images.githubusercontent.com/102838167/161400433-dd4cce07-161f-44b7-b506-378841ac64b4.png)

- ACADEMIA DE FORENSE DIGITAL - AFD (Extração Avançada com Avilla Forensics).
- https://academiadeforensedigital.com.br/
- Sobre o curso: https://academiadeforensedigital.com.br/treinamentos/extracao-logica-avancada-com-avilla-forensics/
- Link curso: https://pay2.provi.com.br/checkout/academia-de-forense-digital?courses=%5B33759%5D
- Conteúdo do Curso: https://drive.google.com/file/d/1mARPeClW1o3EBNIcLh3i9YzBn_fGuSet/view
- Webinar: [![Youtube Badge](https://img.shields.io/badge/-YouTube-ff0000?style=flat-square&labelColor=ff0000&logo=youtube&logoColor=white&link=https://www.youtube.com/watch?v=zQigjIIkBjQ)](https://www.youtube.com/watch?v=zQigjIIkBjQ) 
- https://www.linkedin.com/in/daniel-a-avilla-0987/


## Instalação Avilla Forensics 3.0
- Ferramenta autoexecutável, não requer instalação.
- Execute como administrador o arquivo "Avilla_Forensics.exe".
- Execute a ferramenta a partir do "C:\".
- Exemplo: C:\Forensics".
- Não coloque espaços no nome da pasta da ferramenta.

## Instalação Ferramentas de Terceiros
### Requer JAVA (https://www.java.com/pt-BR/):
- IPED-3.18.12 "C:\Forensics\IPED-3.18.12_and_plugins" (Apenas instalar o JAVA).
- Bycode Viewer: "C:\Forensics\bin\bycodeviewer" (Apenas instalar o JAVA).
- Jadx-1.2.0: "C:\Forensics\bin\jadx-1.2.0" (Apenas instalar o JAVA).
- Backup Extractor: "C:\Forensics\backup_extractor" (Apenas instalar o JAVA).

### Requer PHYTON (https://www.python.org/):
- Instaloader: Para instalar execute o arquivo "C:\Forensics\bin\instaloader-master\instalar.bat" ou:

```python pip install instaloader```

- MVT-1.5.3: Para instalar execute o arquivo "C:\Forensics\bin\mvt-1.5.3\install.bat" ou:

```python pip install mvt```

- Whacipher: Para instalar execute o arquivo "C:\Forensics\bin\pipPython.bat" ou:

```python pip install --upgrade -r requirements.txt```  

## Download
### v1_0_0_168
- https://www.avillaforensics.com.br/forensics.zip
- MD5: 33BA5B2786F1EDF5B87FCC0164EE9505
- SHA1: BED2FAA157F37AA0665974FFC1AE3774BED32212
- SHA256: C8E7DA6C889DBBE1B4A2AD756B548020AA4ECC21B6A318ABA6BBD2AF955C1007
- SHA384: 87355ED5E6D2F7891623908F9ACB8766C8F270D3648C824A003F05162FA341A17E4644AF1796DF31B3C6CF5DF5A4B93C
- SHA512: 8DD4B705CDEFCBB7BD44819EC7435BFC03C5A84B2D8D4C2C5B8A9D088C21E4A5368BA65D0C571783F7DB7F6D7DA307C5D6C101886D85D43A974E15F866F7E955

## Tecnologias utilizadas
- C#.
- Python.
- Java.

## Licença
- Software Livre.

## Contatos
- [![Linkedin Badge](https://img.shields.io/badge/-LinkedIn-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/daniel-a-avilla-0987/)](https://www.linkedin.com/in/daniel-a-avilla-0987/)
- https://www.linkedin.com/in/daniel-a-avilla-0987/
- daniel.avilla@policiacivil.sp.gov.br

## Ferramentas de terceiros inclusas no pacote
- IPED-3.18.12: https://github.com/sepinf-inc/IPED (Requer Java).
- Bytecode Viewer: https://github.com/phith0n/bytecode-viewer (Requer Java).
- Jadx-1.2.0: https://github.com/skylot/jadx (Requer Java). 
- Android Backup Extractor: https://github.com/nelenkov/android-backup-extractor (Requer Java).

- Instaloader: https://github.com/instaloader/instaloader (Requer Python).
- MVT-1.5.3: https://github.com/mvt-project/mvt (Requer Python).
- Whatsapp Encryption and Decryption: https://github.com/B16f00t/whapa (Requer Python).

## Agradecimentos

![LogoGrandecopy](https://user-images.githubusercontent.com/102838167/161445299-a5d6a50f-e2de-440d-bcbc-d364a365e64d.png)

