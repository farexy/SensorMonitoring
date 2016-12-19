import React from 'react';
import ReactDOM from 'react-dom';
import App from './Components/App';
import './Styles/index.css';
//import { Router, Route, IndexRoute, browserHistory } from 'react-router';

/*

 <Router history={browserHistory}>

 <Route path='/' component={App}/>
 <IndexRoute component={App} />
 </Router>,
 */
sessionStorage.setItem('user', null);
ReactDOM.render(
    <App/>,
  document.getElementById('root')
);
