import { Component, Inject, Input, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  @Input() public isLogged: boolean = false;
  public contacts: Contact[] = [];
  public selectedContact: Contact | null = null;
  public newContact: Contact = {};
  public formError: string = '';
  public categories: string[] = ['służbowy', 'prywatny', 'inny'];
  public subcategories: string[] = ['szef', 'klient', 'pracownik'];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    this.loadContacts();
  }

  loadContacts() {
    this.http.get<Contact[]>(this.baseUrl + 'contacts').subscribe(result => {
      this.contacts = result;
      console.log(result);
    }, error => console.error(error));
  }

  showDetails(contact: Contact) {
    this.selectedContact = contact;
  }

  deleteContact(contact: Contact) {
    console.log(contact.id);
    this.http.delete(this.baseUrl + `contacts/${contact.id}`).subscribe(result => {
      const index = this.contacts.findIndex(c => c.id === contact.id);
      if (index !== -1) {
        this.contacts.splice(index, 1);
      }
    }, error => {
      console.error(error);
    });
  }

  onCategoryChange(event: Event) {

    const selectedCategory = (event.target as HTMLSelectElement).value;
    console.log(selectedCategory)
    if (selectedCategory === 'służbowy') {
      this.subcategories = ['szef', 'klient', 'pracownik'];
    } else if (selectedCategory === 'inny') {
      this.subcategories = ['dowolny text'];
    } else {
      this.subcategories = [];
    }
  }

  addContact() {

    this.formError = '';

    this.http.post<Contact>(this.baseUrl + 'contacts', this.newContact).subscribe(result => {

      this.loadContacts();
      this.newContact = {};
    }, error => {
      console.error(error);
      if (error.status === 400) {
        this.formError = 'Niepoprawne dane';
      }
      else {
        this.formError = 'Wystąpił błąd';
      }
    });
  }
}


interface Contact {
  id?: string;
  userName?: string;
  password?: string;
  phoneNumber?: string;
  email?: string;
  firstName?: string;
  lastName?: string;
  birthDate?: Date;
  category?: string;
  subcategory?: string;
}
