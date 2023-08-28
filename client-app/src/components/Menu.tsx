import { useDispatch, useSelector } from "react-redux";
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Button } from "react-bootstrap";
import { RootState } from "../app/store";
import { dark, light } from "../features/theme/themeSlice";
import { Link } from "react-router-dom";

const themeHandler = (theme: string, dispatch: Function) => {
    theme == "light" ? dispatch(dark()) : dispatch(light())
}

const Menu = () => {
    const { theme } = useSelector((state: RootState) => state.theme);
    const dispatch = useDispatch();

    return (
        <nav className="menu">
            <Navbar bg={theme} data-bs-theme={theme} expand="sm">
                <Container>
                    <Navbar.Brand>TeamManagement</Navbar.Brand>
                    <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                    <Navbar.Collapse id="responsive-navbar-nav">
                        <Nav className="me-auto " >
                            <Link to="/">Start</Link>
                            <Link to="/home">Home</Link>
                            <Link to="/docs">Docs</Link>
                        </Nav>
                        <Nav>
                            <Button variant={theme} onClick={() => themeHandler(theme, dispatch)}>Theme: {theme}</Button>

                            <Link to="/authentication">Log In / Register</Link>
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        </nav>
    );
};

export default Menu;