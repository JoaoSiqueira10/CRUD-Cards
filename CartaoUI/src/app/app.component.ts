import { Component, OnInit } from '@angular/core';
import { CartaoService } from './service/cartao.service';
import { Cartao } from './model/cartao.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'cartao';
  cartoes: Cartao[] = [];
  cartao: Cartao = {
    id: '',
    nomeCartao: '',
    numCartao: '',
    vencimentoMes: '',
    vencimentoAno: '',
    cvv: ''
  };

  constructor(private cartaoService: CartaoService){

  }

  ngOnInit(): void {
      this.getAllCartao();
  }

  getAllCartao(){
    this.cartaoService.getAllCartao().subscribe(response => 
      {
        this.cartoes = response;
      }
    );
  }

  onSubmit(){
    if(this.cartao.id === '')
    {
      this.cartaoService.addCartao(this.cartao).subscribe(response => 
        {
          this.getAllCartao;
          this.cartao = {
            id: '',
            nomeCartao: '',
            numCartao: '',
            vencimentoMes: '',
            vencimentoAno: '',
            cvv: ''
          };
        }
      );
    }else{
      this.updateCartao(this.cartao);
    }
  }

  deleteCartao(id:string){
    this.cartaoService.deleteCartao(id).subscribe(
      response => {
        this.getAllCartao();
      }
    );
  }

  populateForm(cartao: Cartao){
    this.cartao = cartao;
  }

  updateCartao(cartao: Cartao){
    this.cartaoService.updateCartao(cartao).subscribe(response => {
      this.getAllCartao()
    });
  }
}
