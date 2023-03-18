import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUser } from '../../Models/LoginUser';

import { AuthService } from '../../Services/AuthService';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent  {

  user:LoginUser={userName:'',password:''};
  
  errorsMessage:string='';



constructor(private authService:AuthService,
  private router:Router){}
 
   submit(usuarioForm:NgForm)
   {
     this.errorsMessage='';
      if (usuarioForm.valid)
      {
        this.authService.login(this.user)
        .subscribe(response=>{
          this.authService.SetTokenInfo(response);
          this.router.navigate(['']);
        },
        (error) => {
          console.log("response con error");
          if (error.status === 401) {
            // handle unauthorized access here
            this.errorsMessage="Clave o usuario incorrecto!"
          } else {
            // handle other errors here
          }
        });
      }
   }


}
