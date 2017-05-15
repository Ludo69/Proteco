#include<stdio.h>

void sumarAsignar(int *a, int b);
void restarAsignar(int *a, int b);
void multiplicarAsignar(int *a, int b);
void dividirAsignar(int *a, int b);

int main(){
int a=30,b=10;
    sumarAsignar(&a,b);
    restarAsignar(&a,b);
    multiplicarAsignar(&a,b);
    dividirAsignar(&a,b);
return 0;

}

void sumarAsignar(int *a, int b){
    *a=*a+b;
    printf("%d \n",*a);
}

void restarAsignar(int *a, int b){
    *a=*a-b;
    printf("%d \n",*a);
}

void multiplicarAsignar(int *a, int b){
    *a=*a*b;
    printf("%d \n",*a);
}


void dividirAsignar(int *a, int b){
    *a=*a/b;
    printf("%d \n",*a);
}
