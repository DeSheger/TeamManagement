import { useSelector } from "react-redux";
import Start from "./Start";
import { RootState } from "../app/store";
import Home from "./Home";
import Docs from "./Docs";
import Authentication from "./Authentication";
import { Route, Routes } from 'react-router-dom';
import Companies from "./Companies/Companies";

const Navigator = () => {
    const { theme } = useSelector((state: RootState) => state.theme)

    return (
        <Routes>
            <Route path="/" element={<Start theme={theme} />}></Route>
            <Route path="/home" element={<Home theme={theme} />}></Route>
            <Route path="/docs" element={<Docs theme={theme} />}></Route>
            <Route path="/authentication" element={<Authentication theme={theme} />}></Route>
            <Route path="/companies" element={<Companies theme={theme} />}></Route>
        </Routes>
    );
};

export default Navigator;