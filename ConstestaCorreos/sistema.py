# -*- coding: utf-8 -*-
#Pyhon 3 lalalala
import smtplib




def enviar(x):
	para=x

	encabezado= 'To:'+para+'\n'+'From: Proteco <'+usuarioGmail+'> \n'+'MIME-Version: 1.0'+'\n'+'Content-type: text/html'+'\n'+'Subject: Prueba\n'
	print(encabezado)

	mensaje= encabezado+'\n<center><h1>Bienvenido a Battle Code!</h1><br><img src="http://s2.subirimagenes.com/otros/previo/thump_9546181ba.jpg"></center>'

	try:
		#hotmail -> "smtp.live.com, 587"
		smtpServer=smtplib.SMTP("smtp.gmail.com",587)
		smtpServer.ehlo()
		smtpServer.starttls()
		smtpServer.ehlo()
		smtpServer.login(usuarioGmail,contraseña)
		smtpServer.sendmail(usuarioGmail,para,mensaje)
		print("Enviado!")
	except Exception as e:
		print("Error: No se puede conectar o enviar el correo")
		print(e)
		smtpServer.close()

usuarioGmail='lara.proteco@gmail.com'
contraseña='Battlecode_'

listaCorreos = ['kurikosa1@hotmail.com', 'somos305@gmail.com']
for x in listaCorreos:
	enviar(x)
