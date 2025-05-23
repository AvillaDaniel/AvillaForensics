![logo avilla 800](https://user-images.githubusercontent.com/102838167/161397689-5df01560-546c-4d82-94a6-e4a3b677875f.png)

## "What we have done for ourselves alone dies with us; what we have done for others and the world remains and is immortal." (Albert Pike)

# 📋 Summary

- Avilla Forensics is a free mobile forensic tool created in February 2021 to assist investigators in collecting information and evidence from mobile devices. Developed by Daniel Avilla, a police officer from São Paulo, the tool provides powerful features for logical data extraction and backup conversion into formats compatible with advanced forensic analysis software, such as IPED and Cellebrite Physical Analyser. Since its inception, Avilla Forensics has received significant updates. Version 3.7 introduced substantial improvements, including an integrity system that generates AES-256 encrypted logs (.avilla). These files contain hashes of the collected data, ensuring that any modifications can be detected. Additionally, the .avilla file includes an HMAC signature, offering an extra layer of protection to verify the authenticity and integrity of the data. These enhancements make Avilla Forensics a more robust and reliable tool for forensic investigations. The tool is highly versatile, enabling direct interaction with mobile devices through the Android Debug Bridge (ADB) interface. Developed in C#, it is fully compatible with Windows 10 and 11 operating systems, functioning stably even in their latest versions. This stability and compatibility make Avilla Forensics a safe and efficient choice for forensic technology specialists. Among its key features is the APK Downgrade module, which enables data collection from over 15 applications, an essential capability for forensic investigations. This module allows downgrading on Android devices without root access, exploiting system vulnerabilities to access app data stored in the DATA region. As of version 3.8, support has been expanded to devices running Android 14 and 15, including exploiting vulnerabilities in Android 12 and 13 to access sensitive information efficiently and securely. Moreover, version 3.8 introduced several innovations that further extend the tool's capabilities. It now allows simultaneous data acquisition from multiple devices, particularly useful in investigations requiring more complex and integrated approaches. Another standout feature is the Avilla App Full Extraction module, which enables the collection of data from any application stored in the DATA partition, including information from secondary profiles registered on the device, without requiring root access or APK downgrades. This functionality significantly broadens the range of accessible data for analysis. With just over three years of existence, Avilla Forensics has evolved impressively, becoming an indispensable tool for specialists worldwide. Currently, the tool supports downgrades for over 400 applications, solidifying its position as an innovative and highly effective solution in the forensic technology field. The international recognition of Avilla Forensics’ quality was reinforced by its winning of the Forensics 4:Cast award in the non-commercial tools category. This award, announced during the SANS Institute event, highlights the tool's importance and contribution to advancing forensic practices.

# Why and when should Avilla Forensics be used? (Por que e quando o Avilla Forensics deve ser utilizado?)

- The best scenario, and the approach that should be prioritized, is conducting a Full File System (FFS) acquisition using proprietary tools. However, if the professional does not have access to paid tools or if they fail to perform a complete extraction, Avilla Forensics comes into play. While it performs a partial acquisition, the tool is a benchmark in this type of acquisition and delivers excellent results, achieving success in nearly 100% of cases. At the very least, it can extract internal storage, WhatsApp, WhatsApp Business, modified versions of WhatsApp, Signal, and various other applications, including on devices running Android 15 and 16.

- According to the principle of sufficiency, even if a full acquisition is not possible, a partial acquisition can provide the necessary and sufficient evidence for a given ongoing investigation, optimizing efforts, time, and reducing unnecessary costs.

- O melhor cenário, e a abordagem que deve ser priorizada, é a realização de uma coleta Full File System (FFS) utilizando ferramentas proprietárias. No entanto, caso o profissional não tenha acesso a ferramentas pagas ou elas falhem na extração completa, entra em cena o Avilla Forensics. Embora realize uma coleta parcial, a ferramenta é uma referência nessa modalidade de aquisição e apresenta excelentes resultados, alcançando sucesso em praticamente 100% dos casos. No mínimo, consegue extrair o armazenamento interno, WhatsApp, WhatsApp Business, versões modificadas do WhatsApp, Signal e diversos outros aplicativos, inclusive em dispositivos com Android 15 e 16.

- De acordo com o princípio da suficiência, ainda que a aquisição completa não seja possível, uma coleta parcial pode fornecer as evidências necessárias e suficientes para uma determinada investigação em andamento, otimizando esforços, tempo e reduzindo custos desnecessários.

- Comparison of a partial acquisition performed by a proprietary tool and by Avilla Forensics.

- Comparação de uma coleta parcial feita por ferramenta proprietária e realizada pelo Avilla Forensics.

![image](https://github.com/user-attachments/assets/57a035af-3a4d-4ccf-9105-c85e696fa4f9)

📱 Avilla Forensics: A Global Revolution in Mobile Forensics
Avilla Forensics is much more than a simple data extraction tool – it represents a revolution in the field of mobile digital forensics. Developed by São Paulo Civil Police officer Daniel Avilla, this free solution for analyzing Android smartphones has been gaining international recognition for its robustness, practicality, and innovation.

🚀 Functional Highlights
Since its creation, Avilla Forensics has become one of the most complete tools for mobile device forensic investigations. Built in C#, the tool is fully compatible with Windows 10 and 11, and its user-friendly interface makes it accessible even to those with limited technical knowledge.

Main features include:

Logical and mass data extraction

AES-256 encrypted logs with HMAC signatures

APK Downgrade module for accessing app data

Full extraction of apps stored in the DATA partition without root

Support for over 400 applications

These features place Avilla Forensics on par with — and often superior to — many expensive commercial tools.

🏆 International Recognition
Avilla Forensics earned 1st place as the Best Non-Commercial Tool of the year in the prestigious Forensics 4:Cast Awards 2023, hosted by the SANS Institute, one of the most respected cybersecurity institutions worldwide.
🔗 https://forensic4cast.com/forensic-4cast-awards/2023-awards/

🌍 Global Community Support

🇷🇺 Russia
Security expert Igor Bederov highlighted Avilla Forensics as one of the best tools for extracting Telegram messages, especially when the device is in airplane mode. He compares it favorably to tools like UFED and Magnet.
🔗 https://ibederov-en.blogspot.com/2023/12/telegramextr.html

He also includes Avilla Forensics in his list of the Top 15 Free Computer Forensics Tools, emphasizing its global impact.
🔗 https://ibederov-en.blogspot.com/2023/12/15forensictools.html

🇪🇨 Ecuador
The UCAPEM Academy offers workshops focused on the APK Downgrade feature of Avilla Forensics, showcasing its practical value in academic and investigative settings.
🔗 https://inforcon.ucapem.com/schedule/apk-downgrade/

The Universidad de Los Hemisferios also offers the course “Análisis Forense en Dispositivos Móviles con Avilla Forensics”, further cementing its role in forensic education across Latin America.
🔗 https://educacioncontinua.uhemisferios.edu.ec/producto/curso-de-analisis-forense-en-dispositivos-moviles-con-avilla-forensics/

🇮🇩 Indonesia
The Rafidh Cell blog, managed by Muhammad Nurkholis, praises version 3.6 of Avilla Forensics for its efficiency, user-friendly interface, and compliance with international forensic standards.
🔗 https://www.rafidhcell.com/2023/11/download-avilla-forensics-v36-gratis.html

🇮🇳 India
In the Digital 4N6 Journal, researchers propose a framework for WhatsApp forensics using open-source tools, with Avilla Forensics as a core component for secure and verified data extraction.
🔗 https://www.researchgate.net/publication/373076630_A_NOVEL_FRAMEWORK_FOR_WHATSAPP_FORENSICS_USING_OPEN-SOURCE_TOOLS
🔗 https://www.academia.edu/105513267/A_NOVEL_FRAMEWORK_FOR_WHATSAPP_FORENSICS_USING_OPEN_SOURCE_TOOLS
🔗 https://www.digital4n6journal.com/

🇧🇷 Brazil
The APECOF association published an article detailing alternative methods for installing apps on Xiaomi devices using Avilla Forensics, overcoming MIUI restrictions.
🔗 https://www.apecof.org.br/index.php/artigos/27-ferramenta-avilla-forensics-explorando-metodos-alternativos-de-instalacao-de-aplicativos-em-dispositivos-xiaomi-com-miui

The Kali Linux Tutorials blog features Avilla Forensics 3.6 as one of the top updates for extracting mobile app data without root.
🔗 https://kalilinuxtutorials.com/avillaforensics-3-6/

🇵🇦 Panama
In the academic journal Revista Cátedra, published by UMECIT University, Avilla Forensics is recognized as a key tool in real-world and academic forensic investigations.
🔗 https://revistas.umecit.edu.pa/index.php/cathedra/article/view/1419
🔗 https://revistas.umecit.edu.pa/index.php/cathedra/article/view/1419/2285

🇬🇪 Georgia – SIS Training
Avilla Forensics was officially taught to members of the State Security Service (SIS) of Georgia, highlighting its growing adoption by national intelligence and security agencies. The training focused on practical mobile extraction using Avilla's advanced modules.

![Imagem do WhatsApp de 2024-06-13 à(s) 07 45 03_e8ac0d66](https://github.com/user-attachments/assets/04a4d2b8-6f04-462f-8ee3-039072a595bd)

🇪🇺 Europe
Avilla Forensics was presented at two major European events:

ITC Crime in Gdynia, Poland, to police agencies and cybercrime experts

![temp_image_20230610_093208_2316a879-51ee-48ab-b4a3-9c07b600eb2a](https://github.com/user-attachments/assets/2061d456-069f-43f2-84b1-4491ac171e1e)

GPEC® Digital 2023 in Frankfurt, Germany, by PHALANX-IT experts, promoting it as a trusted mobile forensics solution for law enforcement

![IMG_0813](https://github.com/user-attachments/assets/b24a17a3-eb01-41b2-afe8-4ec7bee9a0fc)

🇧🇷 National Recognition – Brazil
Avilla Forensics is widely used by forensic experts and investigators across Brazilian law enforcement. It is:

Recommended by the Academia de Forense Digital
🔗 https://academiadeforensedigital.com.br/avilla-forensics-ferramenta-gratuita-de-analise-de-smartphones/

Cited in the JusPodivm forensic book
🔗 https://juspodivmdigital.com.br/cdn/pdf/JUS2867-Degustacao.pdf

Included in expert lists by Joaquim Neto and Wilian Boscolo
🔗 https://www.joaquimneto.com.br/artigos/5-ferramentas-gratuitas-indispensaveis-para-pericia-digital/
🔗 https://wilianboscolo.com.br/forense-em-dispositivos-moveis-com-sistema-operacional-android/

🎓 Training & Education
🇧🇷 Official Training – Academia de Forense Digital
The AFD offers the Official Training Course for Avilla Forensics, covering full functionality, including APK Downgrade, log integrity, and advanced app extraction.
🔗 https://academiadeforensedigital.com.br/treinamentos/treinamento-de-avilla-forensics/

🇧🇷 WB Educação
The course “Tools Created by Police for Telematic Investigation” features Avilla Forensics and ALIAS Extractor, taught by Daniel Hubscher Avilla and Cristiano Ritta.
🔗 https://wbeduca.com.br/pt/cursos/curso-de-ferramentas-criadas-por-policiais-para-investigacao-telematica

🇧🇷 Prof. Marcos Monteiro – APECOF
Monteiro’s Mobile Forensics course includes practical training with Avilla Forensics, addressing both Android and iOS data extraction.
🔗 https://marcosmonteiro.com.br/index.php/perguntas-e-respostas/760-curso-de-forense-em-mobile-smartphones

🤝 Social Impact
Avilla Forensics is also referenced in digital rights advocacy, such as on GenderIT.org, where its open-source and accessible nature is praised as a tool for justice and equity in digital investigations.
🔗 https://genderit.org/feminist-talk/feminist-sparks-reflection-about-digital-forensics

✅ Conclusion
Avilla Forensics stands as one of the greatest Brazilian contributions to global digital investigations. Its presence in research papers, international events, professional training programs, and prestigious awards proves that the project extends far beyond national borders.

It is free, reliable, powerful, and most importantly, built for real-world investigative needs.

If you work in digital forensics, law enforcement, cybersecurity, or academic research — Avilla Forensics is not just recommended — it's essential.

https://www.linkedin.com/pulse/avilla-forensics-uma-revolu%C3%A7%C3%A3o-global-na-per%C3%ADcia-digital-avilla-dvtuf/

# *** (NEW) *** Avilla Forensics 3.8

- Finally, version 3.8 BETA of Avilla Forensics is available! 
- With just over three years of existence, the tool has evolved remarkably, becoming indispensable for experts and users around the world.
- The big highlight of this version is its ability to deal with cases involving mobile devices that use newer operating systems, such as Android 14 and 15. Starting with this update, it is now possible to perform the APK Downgrade on Android 14. In addition, a advanced module that allows access to more storage regions, surpassing traditional collections.
- Another innovative feature is the possibility of performing data acquisition simultaneously on multiple devices, meeting complex demands that require this type of approach.
- Finally, version 3.8 brings the powerful Avilla App Full Extraction as a complement. With this tool, you can collect data from any application on the DATA partition, without the need for root access or APK Downgrade. The feature is even more robust by allowing the extraction of data from secondary profiles registered on the device.
- Downgrade support for over 400 apps. 

Avilla Forensics is located in first place in the award international Forensics 4:Cast 🥇🏆, in the tool category no commercial. Announcement made at the event from the SANS Institute.

Thanks for the votes, without you this would not be possible.

![Capturar](https://github.com/AvillaDaniel/AvillaForensics/assets/102838167/db1ed699-eb99-48e7-9ec9-8475b7e94aad)

## 📋 Trainings (Portuguese) (Advanced Extraction with Avilla Forensics).

- ACADEMIA DE FORENSE DIGITAL - AFD: 
- https://academiadeforensedigital.com.br/
- https://academiadeforensedigital.com.br/treinamentos/treinamento-de-avilla-forensics/ (Gravado)

## 📋 About

- Avilla Forensics is a free mobile forensic tool, launched in February 2021, designed to assist investigators in obtaining information and evidence from mobile devices.
- Developed by São Paulo State Police Officer Daniel Avilla, this tool enables logical data extraction and the conversion of backups to formats compatible with detailed forensic analyses, such as IPED software or Cellebrite Physical Analyser.
- In version 3.7 of Avilla Forensics, numerous improvements and new functionalities for mobile data extraction and analysis were implemented. This update introduced an integrity system that generates AES-256 encrypted logs (.avilla), containing hashes of the collected files. In addition to encryption, the .avilla file features an HMAC signature, creating a second layer of protection for file integrity.
- Version 3.7 significantly enhances the capabilities for data extraction and analysis, offering new integrity functionalities and advanced tools for handling backups and extracting app data. These improvements make the tool even more robust and effective for forensic investigations.
- With features that allow interaction with mobile devices through the Android Debug Bridge (ADB) interface, Avilla Forensics offers a versatile tool that facilitates communication with the device.
- Developed in C#, the tool is compatible and operates stably in Windows 10/11 environments, including their latest updates.
- The main feature of the tool is the APK Downgrade module, which enables data collection from over 15 applications, making it an indispensable tool for forensic investigations.
- The Avilla Forensics suite does not replace existing tools, but complements them, offering new additional possibilities.
  
- From version 3.8 onwards, it is possible to perform APK Downgrade on Android 14.

  ![Captura de tela 2024-10-25 000719](https://github.com/user-attachments/assets/d02c82fc-1226-4522-b37b-04b007211102)
  
- Module that exploits vulnerabilities in Android 12 and 13, to collect data from applications located in the DATA region without the need for Root or Downgrade.

  ![Captura de tela 2024-09-14 011932](https://github.com/user-attachments/assets/ce79232d-2cb2-4cdf-9304-ca7b6bffeced)

- From version 3.8 onwards it is possible to collect data on multiple devices at the same time.

  ![Captura de tela 2024-09-28 102033](https://github.com/user-attachments/assets/ab3cd0ca-2539-4df4-8e7b-8fcc6869bbfd)


## 📋 Webinars

- Avilla Forensics Webinar: Dez 8 2024 - By Anak Kuda (https://www.youtube.com/watch?v=faEiKg2izcg) 

- Avilla Forensics Webinar:Acquisition, Decryption and Parsing of SIGNAL (Version 7.23) with AVILLA SIGNAL EXTRACTION. With Prof. Daniel Avilla - Nov 2 2024 (https://www.youtube.com/watch?v=vKn0yCghE5E&t)

- Avilla Forensics Webinar: Downgrade from Android 14 with Avilla Forensics 3.7.5. With Prof. Daniel Avilla - October 15th. 2024 - AFD (https://www.youtube.com/watch?v=08djLn5i440)

- Avilla App Full Extraction: FORENSICS MOBILE - NEW EXTRACTION METHODS USING AVILLA FORENSICS AND AVILLA FULL APP + IPED - Oct 4 2024 - Emerson Borges (https://www.youtube.com/watch?v=MUmCNDRlroU)

- Avilla App Full Extraction: Security Space collection of Xiaomi models - September 19th. 2024 - Daniel Avilla (https://www.youtube.com/watch?v=HrpAam6zRu0)

- Avilla Forensics: WI-FI debugging and pairing with Avilla Forensics: - September 12th. 2024 - Daniel Avilla (https://www.youtube.com/watch?v=VoNf0baZa_g&t)

- Avilla Forensics: WhatsApp Downgrade APK, for data collection, on a Moto G14 with Android 14: - September 11th. 2024 - Daniel Avilla (https://www.youtube.com/watch?v=zA_Fw8EsmQo)

- Avilla Forensics: APK Downgrade of WhatsApp on Android 14 with the aim of collecting forensic data: -  September 6th. 2024 - Daniel Avilla (https://www.youtube.com/watch?v=gELHf74AIhQ&t)

- Avilla Forensics: Webinar: Avilla Forensics 3.7 - What's new? With Prof. Daniel Avilla - September 3rd. 2024 - AFD (https://www.youtube.com/watch?v=HHPptOdZLaA)

- Avilla Forensics: Security in the palm of your hand: A meeting with Daniel Avilla to talk about Digital Forensics on Mobile Devices - July 4 2024 - Vincit College  (https://www.youtube.com/watch?v=g8gJC1nUngM&t)

- Avilla Forensics: What's New in the New Version - Broadcast live on April 23. 2024 - AFD (https://www.youtube.com/watch?v=H-rtMs3DgmM)

- How to Simulate Applications using Avilla App Simulator (Step by Step Tutorial) - April 23. 2024 - By Wesley Rodrigo - AFD (https://youtu.be/3WNStFaztfc?si=7QUu5SFZ-eONvGRt)
  
- Avilla Universal Whatsapp Extraction - January 5th. 2024 (https://youtu.be/jqF89Xyv-YA?si=OknE6Oo6MLaZCVUj)

- Avilla App Simulator - April 6th. 2023 - AFD (https://www.youtube.com/live/6G4Y3_pk18A?si=Rww8JkobPh9bqKkI) 

- AVILLA FORENSICS 3.5 -  March 17th. 2023 UCAPEM GROUP - (https://www.youtube.com/live/5ndIo1Kx8fk?si=RIKdix6wDkKVVLuj)

- Signal Forensics: Data Extraction and Decryption on Signal -  Nov 24th. 2022 - AFD (https://www.youtube.com/live/NezodJcGyQ4?si=0piGWLhHz1Xbf9hT)

- MOBILE FORENSIC EXTRACTION - USING AVILLA FORENSICS SOFTWARE - LOGIC EXTRACTION AND APK DOWNGRADE - Aug 5 2022 - By Emerson Borges (https://youtu.be/KuSmct1Qa30?si=-D2LbqtkfORdcgfQ)

- Automatic WhatsApp audio transcription with Avilla Forensics - Jul 6. 2022 - AFD (https://www.youtube.com/live/EyYayEqmpkE?si=Cdd8QfP1IcXehNti)
  
- Android Forensics with Avilla Forensics - March 15th. 2022 - AFD (https://www.youtube.com/live/zQigjIIkBjQ?si=uanfwVUt33IqlWXt)


- I have a passion for mobile digital forensics and the art of data extractions.

- "The pursuit of truth and justice through science."
- Daniel Avilla is a professor of Mobile Device Forensics at several renowned institutions, including the Digital Forensics Academy (AFD), UCAPEM GROUP in Ecuador, the Postgraduate Program in Digital Investigation at WB Educacional, Vincit College, and MM Forense. In addition to his academic role, Daniel serves as a Civil Police Officer in the State of São Paulo and as Vice-Director of Technology at the National Association of Forensic Computing Experts (APECOF). He holds a degree in Systems Analysis and a postgraduate specialization in Computer Forensics. Daniel has advanced technical expertise in Mobile Devices and Advanced Extraction methods (such as Chip Off, EDL, and ISP), certified by the AFD. With a research career in technology dating back to 1998, he is the creator of Avilla Forensics — a free tool, widely recognized and internationally awarded, that enhances forensic acquisition on mobile devices.

- "A busca da verdade e justiça pela ciência."
- Daniel Avilla é professor de Forense em Dispositivos Móveis em diversas instituições renomadas, incluindo a Academia de Forense Digital (AFD), a UCAPEM GROUP no Equador, o curso de Pós-Graduação em Investigação Digital da WB Educacional, a Faculdade Vincit e a MM Forense. Além de seu papel acadêmico, Daniel é Agente de Polícia Civil no Estado de São Paulo e atua como Vice-Diretor de Tecnologia na Associação Nacional dos Peritos em Computação Forense (APECOF). Formado em Análise de Sistemas e com especialização em Perícia Forense Computacional, Daniel possui expertise técnica avançada em Dispositivos Móveis e métodos de Extração Avançada (como Chip Off, EDL e ISP), certificada pela AFD. Com uma trajetória de pesquisa em tecnologia iniciada em 1998, ele é o criador da "Avilla Forensics" — uma ferramenta gratuita, amplamente reconhecida e premiada internacionalmente, que otimiza a aquisição forense em dispositivos móveis.

- "La búsqueda de la verdad y la justicia a través de la ciencia."
- Daniel Avilla es profesor de Forense en Dispositivos Móviles en varias instituciones reconocidas, incluidas la Academia de Forense Digital (AFD), UCAPEM GROUP en Ecuador, el Programa de Posgrado en Investigación Digital de WB Educacional, la Facultad Vincit y MM Forense. Además de su rol académico, Daniel se desempeña como Agente de Policía Civil en el Estado de São Paulo y como Vice-Director de Tecnología en la Asociación Nacional de Peritos en Computación Forense (APECOF). Posee una licenciatura en Análisis de Sistemas y una especialización en Pericia Forense Computacional. Daniel cuenta con experiencia técnica avanzada en Dispositivos Móviles y métodos de Extracción Avanzada (como Chip Off, EDL e ISP), certificada por la AFD. Con una trayectoria de investigación en tecnología que comenzó en 1998, es el creador de Avilla Forensics, una herramienta gratuita, ampliamente reconocida y premiada internacionalmente, que optimiza la adquisición forense en dispositivos móviles.

## 🤖 Contacts
- [![Linkedin Badge](https://img.shields.io/badge/-LinkedIn-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/daniel-a-avilla-0987/)](https://www.linkedin.com/in/daniel-a-avilla-0987/)
- https://www.linkedin.com/in/daniel-a-avilla-0987/
- https://www.instagram.com/perito_daniel_avilla
- daniel.avilla@policiacivil.sp.gov.br

## 🌐 Download

### **** (NEW) **** Avilla Forensics 3.8:

Installer version (Setup-Avilla.exe):

- SIZE: 5,14 GB
- Hash Sha-256: aa5c4b1fae3bc9c98e9eb1cd635b6c6a6250580b5de7c13d8b3dbd9da7fd2721
- Hash Sha-512: 79d273e9b10b6c1c557b633f1b0dc658267ccc5e11179be8ac4cee65eea5398742a86079005f9521162c43aea99e817aa6043247cbc7c09fd4c53b047d3c341b

- Download Link:
- https://drive.google.com/file/d/16jbE9uQ464HaRKWC2FSTy-M8GQt2ODmS/view?usp=sharing
    
- Para descompactar utilize o Winrar ou o 7-Zip.  
- Para descomprimir, use Winrar o 7-Zip.
- To unzip, use Winrar or 7-Zip.

VHD format version:

- SIZE: 6,95 GB
- Hash Sha-256: 7a3fac303e031cec9326c8b2aa4f112b09be9d10f65fab647c25789281ae17c9
- Hash Sha-512: 9b144cd72ba8baea9b8973751665b1eb9c7005532075b3dc8a1423ec4f59d6da8f58d3e166500f368f32db3c583df6548ea64df191295613882c67ac1d5fbaf0

- Download Link:
- https://drive.google.com/file/d/1XC7grFDeX2JvzaeVORKas1NumkLIAJL7/view?usp=sharing

- Windows opens and mounts disk drives in VHD automatically. If it does not mount, go to disk management and attach the VHD file to mount it.

 - O Windows abre e monta unidades de disco em VHD de forma automática. Caso não monte, vá em gerenciamento de disco e anexe o arquivo VHD para montá-lo. 
 
### Complementary pack with 400 applications for Downgrade:

- SIZE: 4,91 GB
- Hash Sha-256: 622c51d3c5ea40266e9e8cb977a46949227a09602199567e9ef2ecf7d3653281
- Hash Sha-512: d48cd0a38546d80cad2ae2303260921eb286763e19c93e4ea844d666703d068b1e55a67ff93ad7973c31304cd991e5e15b18b7f6939eb86cd24b507f01670ed9
  
- Download Link:
- Access the website https://academiadeforensedigital.com.br/ and go to the downloads menu.
- Acesse o site https://academiadeforensedigital.com.br/ e vá no menu downloads.

- Atenção, descompacte em "C:\Forensics-3-8\down"
- Atención, descomprime "C:\Forensics-3-8\down"
- Attention, unzip in "C:\Forensics-3-8\down" 
- Password: 1234

- Para descompactar utilize o Winrar ou o 7-Zip.  
- Para descomprimir, use Winrar o 7-Zip.
- To unzip, use Winrar or 7-Zip.

- https://www.win-rar.com/download.html
- https://www.7-zip.org/
  
- Source of apks: https://djangofaiola.blogspot.com/2024/10/happy-3rd-birthday-to-dfapkdngrader.html  

## 🚀 License
Avilla Forensics - Copyleft (C) 2025 – Daniel Hubscher Avilla 

This program is free software: you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program. If not, see <https://www.gnu.org/licenses/>.

# ⭐️ Project description:
- I have a passion for mobile digital forensics and the art of data extractions.
- Free Mobile Forensics Tool that allows you to:
- It is important that you take the training to ensure greater security and success in acquisitions without data loss (Brief training in the English language).
- É importante que você faça o treinamento para garantir maior segurança e sucesso nas aquisições sem perda de dados, veja no final da página.

1.	Backup ADB.
2.	APK Downgrade in 15 Apps: WhatsApp (com.whatsapp), Telegram (org.telegram.messenger), Messenger (com.facebook.orca), ICQ (com.icq.mobile.client), Twitter (com.twitter.android), Instagram (com.instagram.android), Signal (org.thoughtcrime.securems), Linkdin (com.linkedin.android), Tiktok (com.zhiliaoapp.musically), Snapchat (com.snapchat.android), Tinder (com.tinder), Badoo (com.badoo.mobile), Mozilla Firefox (org.mozilla.firefox), Dropbox (com.drobox.android), Alibaba (com.alibaba.intl.android.apps.poseidon)).
3.	Parser Chats WhatsApp.
4. (NEW) Whatsapp .opus audio transcription and transcription plot in CHATS HTML PARSER:
5. Miscellaneous ADB collections: (System Properties (Full), Dumpsys (Full), Disktats (Disk Information), Android Geolocation Dump (Location Manager State), IMEI (01 ,02), S/N (Serial Number), Processes, TCP (Active Internet connections), Accounts (UserInfo), DUMP Wifi, DUMP Detailed Wifi, CPU Information, Memory Information, Display Information (WINDOW MANAGER DISPLAY CONTENTS), Resources, Resolution (Physical size), Screen Dump (.XML file), Dump Backup (Backup Manager is enabled), List Installed Third-Party Applications, List Native System Applications, Contacts, SMS, System Events, Active Users, Android Version, DB Info (Applications Database Info), On/Off History, LogCat, Space In Use Information, Carrier, Bluetooth (Bluetooth Status), Image File Location, Audio File Location, Video File Location, Face Recognition DUMP, Global Settings, Security Settings a, System Settings, Remove/Add PIN (Requires current PIN), DUMP ADB (ADB Connections), Reboot, Reboot Recovery Mode, Reboot Bootloader Mode, Reboot Fastboot Mode.
6. Tracking, Downloading and Decryption of Whatsapp .ENC files.
7. Contact List Search.
8. Deleted WhatsApp Photos Avatars and Contacts.
9. (NEW) Decrypting WhatsApp Databases Crypt 14/15
10. Screenshots.
11. Screen DUMP.
12. Chat Capture.
13. Automatic integration with IPED.
14. (NEW) Access Through the Tool to IPED Tools.
15. Automatic integration with AFLogical.
16. Automatic integration with Alias Connector.
17. Conversion from .AB to .TAR.
18. Fast Scan and Real-time Transfer .
19. Image Finder (Hash, Metadata, Geolocation, Plotting the location on Google Maps and Google Earch).
20. Plotting (IN BATCHES) of the Geolocation of images on Google Earch (geo.kml) with patch and thumbnails of the images.
21. Installing and Uninstalling APKs via ADB.
22. HASH Calculator.
23. Android Folder Browser (PULL and PUSH).
24. Device Mirroring.
25. Instagram Data Scraping.
26. General single copy
27. Automatic integration with MVT-1.5.3.
28. Access Through the Tool to JADX.
29. Access Through the Tool to WhatsApp Viewer.
30. Access Through the Tool to jExiftool GUI.
32. Conversion of .csv/.txt files with GEOLIZATION information provided by court decisions into .KML for police investigations.
32. Merge WhatsApp DATABASES
33. IOS Data Extraction Module

![4](https://user-images.githubusercontent.com/102838167/235308549-9d408ed6-19a8-4707-b8fe-197d2ffb6c85.JPG)

## 🕵️ Functionalities:

### 🤖 Backup ADB:
- Android default backup.
  
### 📱 APK Downgrade in 15 Applications (Access to root files without the need for ROOT):

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

![24](https://user-images.githubusercontent.com/102838167/235308589-4e061b01-8341-4e98-b6ba-43fefeb20b94.JPG)

![Screenshot_20210621-140950](https://user-images.githubusercontent.com/102838167/161463461-c402a208-324f-42c5-a1c2-9f15852731be.png)

![whats](https://user-images.githubusercontent.com/102838167/161398968-0e8fe0a7-5573-4b8e-9e00-450ce7f9e677.PNG)
  
![files-whats](https://user-images.githubusercontent.com/102838167/161401049-7402a3bd-06a2-48d8-9629-d0d93a61982a.PNG)

### 🛠 DOWNGRADE APK Test:
- The tool does a test in a generic application (**com.aplicacaoteste.apk**) before starting the DOWNGRADE process in the target APP.
- Tips: **XIAOMI** phones may come with USB protections, remove these protections **without taking the device out of airplane mode** by following the steps below:

### 💬 (NEW) Parser Chats WhatsApp from NEW Database SCHEME:

1. Select the Chats destination folder (Copy the **"Media"** folder in this same location).
2. Select the folder: **\com.whatsapp\f\Avatars**
3. Select the .DB file: **\com.whatsapp\db\msgstore.db**

- (NEW) In the "Generate Whatsapp Chats" modules it is possible to plot the transcripts in HTML.
- (NEW) You can also transcribe the audios along with Whatsapp parser process.

- New Schema (Table: **message**):
- Fields:
- _id, chat_row_id, from_me, key_id, sender_jid_row_id, status,broadcast, recipient_count, participant_hash, origination_flags, origin, timestamp
received_timestamp, receipt_server_timestamp, message_type, text_data (Mensagens), starred, lookup_tables, message_add_on_flags, sort_id

![2022-04-17 (5)](https://user-images.githubusercontent.com/102838167/163806359-d86b2de8-9aeb-4bdb-a1f6-198b7563317b.png)

### 💬 (NEW) Parser Chats WhatsApp from previous database schema:

1. Select the Chats destination folder (Copy the "Media" folder in this same location).
2. Select the folder: **\com.whatsapp\f\Avatars**
3. Select the .DB file: **\com.whatsapp\db\msgstore.db**

- (NEW) In the "Generate Whatsapp Chats" modules it is possible to plot the transcripts in HTML.
- (NEW) You can also transcribe the audios along with Whatsapp parser process.

- Old Schema (Table: **messages**)
- Fields:
- _id, key_remote_jid, key_from_me, key_id, status, needs_push, data (Mensagens), timestamp, media_url, media_mime_type, media_wa_type, media_size, media_name, media_caption, media_hash, media_durationorigin, latitude, longitude, thumb_image, remote_resource, received_timestamp, send_timestamp,
receipt_server_timestamp, receipt_device_timestamp, read_device_timestamp, played_device_timestamp, raw_data, recipient_count, participant_hash, starred,
quoted_row_id, mentioned_jids, multicast_id, edit_version, media_enc_hash, payment_transaction_id, forwarded, preview_type, send_count, lookup_tables, future_message_type, message_add_on_flags.

![2022-04-17](https://user-images.githubusercontent.com/102838167/163806680-08ae4135-d180-48f5-8c3e-99fc83a86a34.png)

### 💬 (NEW) Whatsapp .opus audio transcription and transcription plot in CHATS HTML PARSER:

- In the "OPUS audio transcription" module you can transcribe one or thousands of audios at the same time.
- In the "Generate Whatsapp Chats" modules it is possible to plot the transcripts in HTML.
- You can also transcribe the audios along with Whatsapp parser process.
- Generate HTML report with transcribed texts, hash, contact linked to audio and chat linked to audio.

![Print-Opus](https://user-images.githubusercontent.com/102838167/176755084-6182aba3-5e71-4d50-b2e1-9ede2b20b632.PNG)

![parser](https://user-images.githubusercontent.com/102838167/176756128-efc2febf-56da-4083-be5b-31604418083b.PNG)

![Print_relatorio-audios](https://user-images.githubusercontent.com/102838167/177615504-59968751-d504-496d-bfa8-1316a5790c46.PNG)

### 📱 Miscellaneous ADB collections in .TXT format:
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

### ⚡️ (NEW) Tracking, Downloading and Decrypting Whatsapp .ENC Files:

![2022-04-10](https://user-images.githubusercontent.com/102838167/163823905-47262d30-d4c2-4a69-957a-80a765372247.png)
- Generate the Script and run the generated **.bat** file.

"C:\Forensics\bin\whatsapp-media-decrypt\decrypt.py"

### ⚡️ (NEW) Contact List Search, Avatar Photos and Deleted WhatsApp Contacts:

1. Select the folder: **\com.whatsapp\f\Avatars**
2. Select .DB file: **\com.whatsapp\db\wa.db**

![contatos](https://user-images.githubusercontent.com/102838167/163809831-53167b37-2da5-43d0-96dd-9b596f1d2191.PNG)

### (NEW) 📐 WhatsApp Database Decryption:
- Crypt14.
- **Crypt15.**

![3](https://user-images.githubusercontent.com/102838167/184434584-78a39ba9-6879-4c98-b512-4c91a81d0966.PNG)

### 📸 Screenshots, Screen DUMP and Chat Capture: 

![2022-04-03 (1)](https://user-images.githubusercontent.com/102838167/161448487-b4dea9e4-9293-4b65-8981-1de07caf7288.png)

![2022-04-03 (2)](https://user-images.githubusercontent.com/102838167/161448491-d9622700-c41e-41b0-8442-a055def05913.png)

### 🚀 (NEW) Access Through the Tool to IPED Tools.
- "Z:\bin\IPEDTools\IPEDTools.exe"

![2](https://user-images.githubusercontent.com/102838167/184431890-01639fa1-82ad-4052-8e5e-e1eeaa621124.PNG)

### 🚀 Automatic integration with AFLogical OSE 1.5.2:

- Performs the acquisition automatically without user intervention.
- "Z:\bin\AFLogicalOSE152OSE.apk"

![af](https://user-images.githubusercontent.com/102838167/161461445-74dc290d-7ba7-4369-8248-a796f7299c19.PNG)

### 🚀 Automatic integration with Alias Connector:
- Performs the acquisition automatically without user intervention.
- "Z:\bin\com.alias.connector.apk"

![alias](https://user-images.githubusercontent.com/102838167/161463618-61745835-59f8-4d37-9512-f714dbc6effc.PNG)

### 📐 Conversion from .AB to .TAR:
- Passworded ADB backups may take longer to convert.
- Try not to put passwords in the backups requested in "ADB Backup" or "Downgrade", so you speed up the conversion process.
- If this module doesn't work, try to add the **"Z:\"** patch to the system variables

![variaveis](https://user-images.githubusercontent.com/102838167/161451033-a41c46a0-35cb-4c3b-9aa3-cafee9c92284.PNG)

### ♻ Fast Scan and Real-time Transfer:
- Images: .jpg, .jpeg, .png, .psd, .nef, .tiff, .bmp, .tec, .tif, .webp
- Videos: .aaf, .3gp, .asf, .avi, .m1v, .m2v, .m4v, .mp4, .mov, .mpeg, .mpg, .mpe, .mp4, .rm, .wmv, .mpv , .flv, .swf
- Audios: .opus, .aiff, .aif, .flac, .wav, .m4a, .ape, .wma, .mp2, .mp1, .mp3, .aac, .mp4, .m4p, .m1a, .m2a , .m4r, .mpa, .m3u, .mid, .midi, .ogg
- Archives: .zip, .rar, .7zip, .7z, .arj, .tar, .gzip, .bzip, .bzip2, .cab, .jar, .cpio, .ar, .gz, .tgz, .bz2
- Databases: .db, .db3, .sqlite, .sqlite3, .backup (SIGNAL)
- Documents: .htm, .html, .doc, .docx, .odt, .xls, .xlsx, .ppt, .pptx, .pdf, .txt, .rtf
- Executables: .exe, .msi, .cmd, .com, .bat, .reg, .scr, .dll, .ini, .apk
- 
![2022-04-03 (5)](https://user-images.githubusercontent.com/102838167/161448785-6c0b41a0-3fa3-448c-bcf9-5836e92632c1.png)

### 🔠  Image Finder (Hash, Metadata, Geolocation, Plot location on Google Maps and Google Earch):

- Note: For this module DO NOT save your acquisitions on the Desktop, save for example in "C:\folder_name\collection_01" to run the image search.

![2022-03-31 (2)](https://user-images.githubusercontent.com/102838167/161401187-e5c5f707-1601-4e17-8007-49931a6c1784.png)

![2022-03-31 (3)](https://user-images.githubusercontent.com/102838167/161401191-49f18d65-61a3-49a9-a7b4-ba580fddc319.png)

https://user-images.githubusercontent.com/102838167/161446333-ddcbe368-7b03-4090-b10c-5cd6f32ad023.mp4

### 📜 (NEW) Plot (BATCH) of Geolocation of images on Google Earch (geo.kml) with patch and thumbnails of images:

- Note: To plot the thumbnails along with the yellow points, download **Google Earch Pro**, if you plot on Google Earch Online, only the blue points will be plotted without the images.
- Click on **GENERATE KML** to batch generate the **geo.kml** file

![geo](https://user-images.githubusercontent.com/102838167/163811621-3a1c69f3-f74f-4488-a943-c866903a0341.PNG)

![2022-04-06](https://user-images.githubusercontent.com/102838167/163807399-c8de39b5-f8a1-4632-9d77-ba19ca2cd354.png)

![2022-04-10 (6)](https://user-images.githubusercontent.com/102838167/163807446-07ec29a1-7393-4d98-9a47-7de8cf4a31ab.png)

![2022-04-10 (8)](https://user-images.githubusercontent.com/102838167/163808357-38af47df-141c-400f-b848-634a7ef06ca3.png)

![2022-04-10 (9)](https://user-images.githubusercontent.com/102838167/163808370-955743bd-bec6-483a-a8e2-e6e0b3349fca.png)

### 🛠 Installing and Uninstalling APKs via ADB:
- .APK files

### ⏳ HASH Calculator:
- Note: For this module DO NOT save your acquisitions on the Desktop, save for example in "C:\folder_name\collection_02" to calculate the Hashs of the files.
- Calculates the Hash of all files in an acquisition.
- SHA-256.
- SHA-1.
- SHA-384.
- SHA-512.
- SHA-MD5.

![2022-03-28 (9)](https://user-images.githubusercontent.com/102838167/161402185-07ef2510-735f-4940-b56a-a7624e42f711.png)

### 📱 (NEW) Android Folder Browser (PULL and PUSH):
- A Simple folder browser to PULL and PUSH files or folders.

![2022-04-10 (1)](https://user-images.githubusercontent.com/102838167/163810052-a45ec6cc-8e92-4ff7-bfcd-b6da09e44a31.png)

### 🎥 Device Mirroring:
- "C:\Forensics\bin\scrcpy"

![espeçhamento](https://user-images.githubusercontent.com/102838167/161463105-71285aa7-715c-450f-b259-c40c00b3a0a7.PNG)

### 🚀 Instagram data scraping:

![2022-04-03 (7)](https://user-images.githubusercontent.com/102838167/161449129-c23ca774-f268-49ac-b7cf-30b1a305d4e5.png)

### 🚀 General single copy:

- If you have problems with "adb pull" or "adb backup", copy all files from the device in separate processes, copying one at a time.

![1](https://user-images.githubusercontent.com/102838167/184433978-562436fb-3e5a-4bad-a00c-c9a932aa9bb2.PNG)

### 🚀 Access Through the Tool to JADX (Dex to Java Decompiler):
- "C:\Forensics\bin\jadx-1.2.0\jadx-gui-1.2.0-no-jre-win.exe"

### 🚀 Access Via Tool to WhatsApp Viewer:
- "C:\Forensics\bin\WhatsAppViewer.exe"

### 📱 Conversion of .csv/.txt files with GEOLIZATION information provided by court decisions into .KML for police investigations.
- Plotting thousands of points on the map in seconds
- In this example below, more than 36 thousand points were plotted on the map
- Example data from .csv file: 2022-04-15T02:59:45.368Z,2022-04-15T02:59:45.368, (Latitude/Column 2) -23.7416538, (Longitude/Column 3) -46.5744873,15,WIFI,1663554331,ANDROID

![print-kml-1](https://user-images.githubusercontent.com/102838167/176760912-73580348-6503-43b6-b1dc-071996cca99d.PNG)

![plotagem2](https://user-images.githubusercontent.com/102838167/176758721-70e53924-bc1f-4c83-bb81-54061fb1a328.PNG)

![plotagem3](https://user-images.githubusercontent.com/102838167/176758738-fea4c916-9bea-4cb3-9190-24e199522aa2.PNG)

### (NEW) 📱 Merge WhatsApp DATABASES:

- "Z:\bin\merge\merge_databases_exe\merge_databases.exe -lv"

![merge](https://user-images.githubusercontent.com/102838167/202287723-390aabae-6d06-47aa-975b-360a0c0bb841.PNG)

## ⚙️ Tool Prerequisites:
- TECHNICAL knowledge of Forensics in Mobile Devices.
- Minimal computer knowledge
- Device with DEBUG mode activated.
- Windows 10/11 with its proper updates.

## ⚙️ Prerequisites Third-Party Tools: 
- JAVA (https://www.java.com/pt-BR/).
- PHYTON (https://www.python.org/).

## 💻 Installation Avilla Forensics 3.8

VHD format:
- Windows opens and mounts disk drives in VHD automatically. If it does not mount, go to disk management and attach the VHD file to mount it.
- O windows abre e monta unidades de disco em VHD de forma automática. Caso não monte, vá em gerenciamento de disco e anexe o arquivo VHD para montá-lo. 
- **Do not put spaces in the tool folder name.**

![INSTALL](https://user-images.githubusercontent.com/102838167/235308795-9bbf5afd-24b3-4be9-b011-d4b53e6fabed.PNG)

## 💻 Installing Third-Party Tools
### Requires JAVA (https://www.java.com/pt-BR/):
- Jadx-1.2.0: "C:\Forensics\bin\jadx-1.2.0" (Just install JAVA). (APACHE LICENSE)
- Backup Extractor: "C:\Forensics\backup_extractor" (Just install JAVA). (APACHE LICENSE)
- The Backup Extractor module (.AB to .TAR) may require you to add the "C:\Forensics" patch to the system variables.

### 🚀 Donate:

- CHAVE PIX: 3901d8ea-22ca-4ba8-a0fb-2615e5485b2c

## ⚙️ Technologies used
- C#.
- Python.
- Java.  

## 📱  Third-party tools included in the package

- **APACHE LICENSE**
- ADB: https://developer.android.com/tools/adb (APACHE LICENSE).
- Jadx-1.2.0: https://github.com/skylot/jadx (Requer Java). (APACHE LICENSE).
- Android Backup Extractor: https://github.com/nelenkov/android-backup-extractor (Requires Java). (APACHE LICENSE).
- Instaloader: https://github.com/instaloader/instaloader (Requires Python). (APACHE LICENSE).
- Screen Copy: https://github.com/Genymobile/scrcpy (APACHE LICENSE).

- **GNU GENERAL PUBLIC LICENSE**
- Libimobiledevice: https://github.com/libimobiledevice/libimobiledevice (GNU GENERAL PUBLIC LICENSE). (FormIOS.cs)
- IPED: https://github.com/sepinf-inc/IPED (GNU GENERAL PUBLIC LICENSE)
- IPED PARSERS: https://github.com/sepinf-inc/IPED/tree/master/iped-parsers/iped-parsers-impl/src/main/resources/iped/parsers/whatsapp https://github.com/tc-wleite (GNU GENERAL PUBLIC LICENSE). (WhatsParser.cs and WhatsParserAntigocs.cs)
- IPEDTools: https://github.com/thiagofuer/IPEDTools_Releases/releases (GNU GENERAL PUBLIC LICENSE)
- AFLogical OSE 1.5.2: https://github.com/nowsecure/android-forensics (GNU GENERAL PUBLIC LICENSE).
- WhatsApp-Crypt14-Crypt15-Decrypter: https://github.com/ElDavoo/WhatsApp-Crypt14-Crypt15-Decrypter (Requires Python). (GNU GENERAL PUBLIC LICENSE). (FormDecript.cs)
- SQLiteStudio: https://github.com/pawelsalawa/sqlitestudio (GNU GENERAL PUBLIC LICENSE).
- jExifToolGUI: https://github.com/hvdwolf/jExifToolGUI (GNU GENERAL PUBLIC LICENSE).
- GpsPrune: https://activityworkshop.net/software/gpsprune/ https://github.com/activityworkshop/GpsPrune (GNU GENERAL PUBLIC LICENSE).
- Bytecode Viewer: https://github.com/Konloch/bytecode-viewer (GNU GENERAL PUBLIC LICENSE).

- **MIT LICENSE**
- ALEAPP: https://github.com/abrignoni/ALEAPP (MIT LICENSE).
- iLEAPP: https://github.com/abrignoni/iLEAPP (MIT LICENSE).  
- Hashcat: https://hashcat.net/hashcat/ (MIT LICENSE).
- Whatsapp-Viewer https://github.com/andreas-mausch/whatsapp-viewer (MIT LICENSE).
- iTunes-Backup-Explorer: https://github.com/MaxiHuHe04/iTunes-Backup-Explorer (MIT LICENSE).
  
- **BSD LICENSE**
- Audio transcription: https://github.com/Uberi/speech_recognition (BSD LICENSE).

- **Freeware LICENSE**  
- Alias Connector: http://www.newseg.seg.br/newseg/ (Freeware LICENSE). 
- Audio transcription: http://www.newseg.seg.br/newseg/ (Freeware LICENSE)

 - **PUBLIC DOMAIN**  
 - Itunes_backup2hashcat: https://github.com/philsmd/itunes_backup2hashcat/ (PUBLIC DOMAIN).

- **UNDEFINED**  
- Whatsapp-media-decrypt: https://github.com/sh4dowb/whatsapp-media-decrypt (Requires Python). (UNDEFINED).
- Grep: https://git-scm.com/docs/git-grep. (UNDEFINED).  

## 😎 Thanks

![LogoGrandecopy](https://user-images.githubusercontent.com/102838167/161445299-a5d6a50f-e2de-440d-bcbc-d364a365e64d.png)
