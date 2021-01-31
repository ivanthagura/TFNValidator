import React from 'react';
import TFNForm from '../tfnForm/TFNForm';

function HomePage() {
    return(
        <div className="jumbotron vertical-center">
            <h1>Tax file validator</h1>
            <br />
            <h3> Welcome to the Australian tax file validator form</h3>
            <br />
            <h5> Input your Tax file number and we will validate it for you!!</h5>
            <br />
            <br />
            <TFNForm/>
        </div>
    );
}

export default HomePage;