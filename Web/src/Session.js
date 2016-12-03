/**
 * Created by Александр on 12.11.2016.
 */
import { User } from "./Models/User";

export class Session {

    // don't sure about saving data in session storage because we use static session class.
    // it should exist the same time as session. But repeating myself don't sure.
    
    static key = "user";
    static user = null;

     static  getAuthenticatedUser() { return Session.user; }
     static  setAuthenticatedUser(user) {
        sessionStorage.setItem('people-locator-user', JSON.stringify(user));
        Session.user = user;
    }
    
     static  Init() {
        var sessionValue = JSON.parse(sessionStorage.getItem(Session.key));

        if (sessionValue != null) {
            Session.user = new User(sessionValue.id, sessionValue.login, sessionValue.password, sessionValue.email);
        } 
    }

}

