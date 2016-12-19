import { User } from "./Models/User";
/*
export class SessionManager {

    // don't sure about saving data in session storage because we use static session class.
    // it should exist the same time as session. But repeating myself don't sure.

    static key = "user";
    static user = null;

     static  getAuthenticatedUser() { return SessionManager.user; }
     static  setAuthenticatedUser(user) {
        sessionStorage.setItem('user', JSON.stringify(user));
        SessionManager.user = user;
    }

     static  Init() {
        var sessionValue = JSON.parse(sessionStorage.getItem(SessionManager.key));

        if (sessionValue != null) {
            SessionManager.user = new User(sessionValue.id, sessionValue.login, sessionValue.password, sessionValue.email);
        }
    }

}*/

