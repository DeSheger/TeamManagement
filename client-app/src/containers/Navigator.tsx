import { useSelector } from "react-redux";
import Start from "./Start";
import { RootState } from "../app/store";
import Home from "./Home";
import Docs from "./Docs";

const Navigator = () => {
    const navigator = useSelector((state: RootState) => state.navigator)

    return (
        <>
            {navigator.start ? <Start /> : null}
            {navigator.home ? <Home /> : null}
            {navigator.docs ? <Docs /> : null}
        </>
    );
};

export default Navigator;