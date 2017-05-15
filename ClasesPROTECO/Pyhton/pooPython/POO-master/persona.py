#!/usr/bin/python
#-*-coding:utf-8-*-

class Persona:									
	def __init__(self, nombre, edad): #"Método constructor"
						#self es una convención, se guarda la referencia al objeto creado	
		self.nombre= nombre
		self.edad = edad
		print ('Soy un nuevo objeto')	

	def correr (self):
		print ("Estoy corriendo")
	def saludar(self, mensaje): 									    
		print (mensaje)							

#luis = Persona()								#intanciando, creando un objeto de la calse persona
luis = Persona ("Luis",19)							#instanciado un objeto con un atributo
ricardo = Persona ("Ricardo",21)
paula = Persona("Paula",40)

print ("Mi nombre es "+luis.nombre+" y tengo",luis.edad)			
print ("Mi nombre es "+ricardo.nombre+" y tengo",ricardo.edad)
print ("Mi nombre es "+paula.nombre+" y tengo",paula.edad)

luis.correr()
ricardo.correr()
paula.correr()

luis.saludar("Hola soy "+luis.nombre) 					#accediendo al metodo mediante el objeto, no mandamos self, solo mandamos el argumento mensaje.
ricardo.saludar("Hola soy "+ricardo.nombre)
paula.saludar("Hola soy "+paula.nombre)
