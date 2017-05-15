#include<stdio.h>

void swap(char *a, char *b);

int main(){
char a='O',b='X';
    swap(&a,&b);
    printf("%c %c",a,b);
return 0;

}

void swap(char *a, char *b){
    char temp;
    temp=*a;
    *a=*b;
    *b=temp;
}