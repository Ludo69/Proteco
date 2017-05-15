#!/usr/bin/python
#-*-coding:utf-8-*-

class Persona:
	def __init__(self, nombre, edad):
		self.nombre = nombre
		self.edad = edad
	def correr (self):
		print ("Estoy corriendo y soy",self.nombre)
	def saludar(self, mensaje):
		print (mensaje)

class Araña(object):
	def __init__(self, color):
		self.color = color
	def tejer(self):
		print("Estoy tejiendo")

class Programador(Persona):
	def programar(self, lenguaje):					#creando metodo programar exclusivo de programador que recibe el argumento lenguaje
		print ("Estoy programando en", lenguaje)

class Contador(Persona):							
	def contar(self, cosas):						
		print ("Estoy contando", cosas)

class HombreAraña(Persona, Araña):
	def salvarAlMundo(self):
		print("Estoy salvando al mundo")


luis = Programador("Luis", 19)								
pablo = Contador("Pablo", 21)
peter = HombreAraña("Peter Parker", 28)														

luis.correr()
pablo.correr()

luis.saludar("Hola soy "+luis.nombre+" y antes de Programador soy Persona.") 
pablo.saludar("Hola soy "+pablo.nombre+" y también soy Persona.")

luis.programar("Python")
pablo.contar("Números")	

peter.saludar("Hola soy "+peter.nombre+" y antes de ser Araña soy Persona por eso tengo nombre y edad")
peter.tejer()
peter.salvarAlMundo()