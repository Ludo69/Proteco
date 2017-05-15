class Flor:
	def __init__(self, petalos):
		self.petalos=petalos
	def verPetalos(self):
		print("Quedan ", self.petalos, " petalos")
	def arrancaPetalo(self):
		self.petalos=(self.petalos-1)
		if(self.petalos%2==1):
			print ("Me quiere")
		else:
			print("No me quiere")
	def quedanPetalos(self):
		if(self.petalos>=0):
			return True
		else:
			return False

	def decidir(self):
		if(self.petalos%2==1):
			print("Me caso")
		else:
			print("No hay problema la vida sigue :(")	
flor = Flor(8)

while(flor.quedanPetalos()):
	flor.verPetalos()
	flor.arrancaPetalo()
flor.decidir()
