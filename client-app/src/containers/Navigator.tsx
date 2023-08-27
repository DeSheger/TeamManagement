import { useSelector } from "react-redux";
import Start from "./Start";
import { RootState } from "../app/store";
import Home from "./Home";
import Docs from "./Docs";
import Authentication from "./Authentication";

const Navigator = () => {
    const navigator = useSelector((state: RootState) => state.navigator)
    const {theme} = useSelector((state: RootState) => state.theme)

    return (
        <>
            {navigator.start ? <Start theme={theme}/> : null}
            {navigator.home ? <Home theme={theme}/> : null}
            {navigator.docs ? <Docs theme={theme}/> : null}
            {navigator.login ? <Authentication theme={theme}/> : null}
        </>
    );
};

export default Navigator;