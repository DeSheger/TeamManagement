import React, { useState } from 'react';
import Layout from './Layout';
import { Button, Form } from 'react-bootstrap';
import loginService from '../services/loginService';
import { useDispatch } from 'react-redux';

const Authentication = ({ theme, logIn }: any) => {

    const [LogInForm, setLogInForm] = useState(true);
    const [email, setEmail] = useState("");
    const [name, setName] = useState("");
    const [surrname, setSurrname] = useState("");
    const [password, setPassword] = useState("");
    const dispatch = useDispatch();

    return (
        <div className='authentication'>
            <div className='authentication__form'>
                {LogInForm ?
                    <Form className={`form-${theme}`}>
                        <Form.Group className="mb-3" controlId="formBasicEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control type="email" placeholder="Enter email" value={email}
                                onChange={(e) => setEmail(e.target.value)}/>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" placeholder="Password" value={password}
                                onChange={(e) => setPassword(e.target.value)}/>
                        </Form.Group>
                        
                        <Button variant="primary" onClick={() => loginService(email, 
                            password, dispatch)}>
                            Log In
                        </Button>
                        <Button variant={theme} onClick={() => setLogInForm(false)}>
                            Or Register
                        </Button>
                    </Form> :
                                    // Register Form //
                    <Form className={`form-${theme}`}>
                        <Form.Group className="mb-3" controlId="formBasicEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control type="email" placeholder="Enter email" value={email}
                                onChange={(e) => setEmail(e.target.value)}/>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicText">
                            <Form.Label>Name</Form.Label>
                            <Form.Control type="text" placeholder="Enter name" value={name}
                                onChange={(e) => setName(e.target.value)}/>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicText">
                            <Form.Label>Surrname</Form.Label>
                            <Form.Control type="text" placeholder="Enter name" value={surrname}
                                onChange={(e) => setSurrname(e.target.value)}/>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" placeholder="Password" value={password}
                                onChange={(e) => setPassword(e.target.value)}/>
                        </Form.Group>
                        
                        <Button variant="primary" onClick={(e) =>e.preventDefault()}>
                            Register
                        </Button>
                        <Button variant={theme} onClick={() => setLogInForm(true)}>
                            Or Log In
                        </Button>
                    </Form>
                }
            </div>
        </div>
    );
}

export default Authentication;