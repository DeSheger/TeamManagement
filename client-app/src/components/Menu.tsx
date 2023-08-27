import { useDispatch, useSelector } from "react-redux";
import { start, home, docs, login } from "../features/navigator/navigatorSlice";
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Button } from "react-bootstrap";
import { RootState } from "../app/store";
import { dark, light } from "../features/theme/themeSlice";

const themeHandler = (theme: string, dispatch: Function) => {
    theme=="light"?dispatch(dark()):dispatch(light())
}

const Menu = () => {
    const {theme} = useSelector((state: RootState) => state.theme);
    const dispatch = useDispatch();

    return (
        <Navbar bg={theme} data-bs-theme={theme} expand="sm">
            <Container>
                <Navbar.Brand onClick={() => dispatch(start())}>TeamManagement</Navbar.Brand>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">
                <Nav className="me-auto " >
                    <Nav.Link onClick={() => dispatch(start())}>Start</Nav.Link>
                    <Nav.Link onClick={() => dispatch(home())}>Home</Nav.Link>
                    <Nav.Link onClick={() => dispatch(docs())}>Docs</Nav.Link>
                </Nav>
                <Nav>
                    <Button variant={theme} onClick={() => themeHandler(theme,dispatch)}>Theme: {theme}</Button>
                    <Nav.Link onClick={() => dispatch(login())}>Log In</Nav.Link>
                    <Nav.Link onClick={() => dispatch(login())}>Sign In</Nav.Link>
                </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
};

export default Menu;