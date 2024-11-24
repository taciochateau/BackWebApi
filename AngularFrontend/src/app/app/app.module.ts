import { Component } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';

@Component({
  selector: 'app-root',
  template: `
    <div>
      <h1>Client Management</h1>
      <app-client-list></app-client-list>
      <app-client-form></app-client-form>
    </div>
  `,
  styleUrls: ['./app.component.css']
})
export class AppComponent {}

@NgModule({
    imports: [
      AppRoutingModule,
      // outros módulos...
    ]
  })
