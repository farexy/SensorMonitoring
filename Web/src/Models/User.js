/**
 * Created by Александр on 12.11.2016.
 */
export class User {
    constructor(data) {
        this.email = data.email;
        this.id = data.id;
        this.fullName = data.fullName;
        this.password = data.password;
    }

    get Id() { return this.id; }

    get FullName() { return this.fullName; }
     set FullName(value) { this.fullName = value; }

     get Password() { return this.password; }
     set Password(value) { this.password = value; }

     get Email() { return this.email; }
     set Email(value) { this.email = value; }


}