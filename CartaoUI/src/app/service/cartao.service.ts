import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cartao } from '../model/cartao.model';

@Injectable({
  providedIn: 'root'
})
export class CartaoService {

  baseUrl = 'https://localhost:7246/api/cartao';

  constructor(private http: HttpClient) { }

  // Get all cartoes
  getAllCartao(): Observable<Cartao[]>{
    return this.http.get<Cartao[]>(this.baseUrl);
  }

  addCartao(cartao : Cartao): Observable<Cartao>{
    cartao.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Cartao>(this.baseUrl, cartao);
  }

  deleteCartao(id: string): Observable<Cartao>{
   return this.http.delete<Cartao>(this.baseUrl + '/' + id);
  }

  updateCartao(cartao: Cartao): Observable<Cartao>{
    return this.http.put<Cartao>(this.baseUrl + '/' + cartao.id, cartao);
  }
}
