function relogio(){

	
	//criamos a variavel objeto momentoAtual, que contera a data atual
	var momentoAtual = new Date(); 
	
	//Pegamos em variaveis separadas, hora, minuto e segundo
    var hora = momentoAtual.getHours(); 
    var minuto = momentoAtual.getMinutes();
    var segundo = momentoAtual.getSeconds();
	
	//verificamos se segundo, minuto e hora é menor que 9 se for concatenamos adicionando um zero a esquerda
	if(segundo <=9 )
	{
	   segundo = "0"+segundo;	
	};
	if(minuto <=9 )
	{
	   minuto = "0"+minuto;	
	};
	if(hora <=9 )
	{
	   hora = "0"+hora;	
	};
	
	
	// pegamos dia, mes e ano do objeto momento atual
	var dia = momentoAtual.getDate();
	var mes = momentoAtual.getMonth();
	var ano = momentoAtual.getFullYear();
	var comp = null;
	
	//descobriremos agora o nome do mês atual
	switch(mes)
	{
		case 0:
		mes = "Janeiro";
		break;
		case 1:
		mes = "Fevereiro";
		break;
		case 2:
		mes = "Mar&ccedilo";
		break;
		case 3:
		mes = "Abril";
		break;
		case 4:
		mes = "Maio";
		break;
		case 5:
		mes = "Junho";
		break;
		case 6:
		mes = "Julho";
		break;
		case 7:
		mes = "Agosto";
		break;
		case 8:
		mes = "Setembro";
		break;
		case 9:
		mes = "Outubro";
		break;
		case 10:
		mes = "Novembro";
		break;
		case 11:
		mes = "Dezembro";
		break;
	}

	//dia da semana

	var hoje=new Date();
	var dia_semana= hoje.getDay();
	var semana=new Array(6);

	semana[0]='Domingo';
	semana[1]='Segunda';
	semana[2]='Ter&ccedil;a';
	semana[3]='Quarta';
	semana[4]='Quinta';
	semana[5]='Sexta';
	semana[6]='S&aacute;bado';




   // contatenamos a string do relogio
    //horaImprimivel = dia + " de " + mes + " de " + ano  +" | "+ hora +":"+minuto+":"+segundo;
    var data_atual = dia + " de " + mes + " de " + ano;
    var hora_atual = semana[dia_semana] + ", " + hora +":"+minuto+":"+segundo;
	
	//utilizando jquery exibimos na div de id relogio o relogio
    $("#hora_atual").html(hora_atual);
    $("#data_atual").html(data_atual);
	
    
	//logo abaixo chamamos a função a cada um 1 segundo para reatualizar o relogio
	setTimeout("relogio()",1000);
}

// esta  é a função jquery que chama o relogio
$(function(){
	relogio();
});