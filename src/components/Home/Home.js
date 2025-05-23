import React,{ useEffect } from 'react';
import { withRouter } from 'react-router-dom';
import { ACCESS_TOKEN_NAME, API_BASE_URL } from '../../constants/apiConstants';
import axios from 'axios'
function Home(props) {
    useEffect(() => {
        axios.get(API_BASE_URL+'/api/Auth/Validate', { headers: { 'token': localStorage.getItem(ACCESS_TOKEN_NAME) }})
        .then(function (response) {
            if(response.status !== 200){
              window.location.pathname="/login";
            }
        })
        .catch(function (error) {
              window.location.pathname="/login";
        });
      },[])
    function redirectToLogin() {
              window.location.pathname="/login";
    }
    return(
        <div className="mt-2">
            Home page content
        </div>
    )
}

export default withRouter(Home);