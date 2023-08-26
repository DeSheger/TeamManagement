import { useDispatch } from "react-redux";
import { start, home, docs } from "../features/navigator/navigatorSlice";

const Menu = () => {
    const dispatch = useDispatch();
    return (
        <nav className="menu">
            <ul className="menu__list">
                <li className="menu__item" onClick={() => dispatch(start())}>Start</li>
                <li className="menu__item" onClick={() => dispatch(home())}>Home</li>
                <li className="menu__item">Login</li>
                <li className="menu__item" onClick={() => dispatch(docs())}>Docs</li>
                <li className="menu__item">Profile</li>
            </ul>
        </nav>
    );
};

export default Menu;