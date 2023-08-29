import axios from "axios"
import sessionCookie from "../cookies/sessionCookie";
import { session } from "../features/session/sessionSlice";

const loginService = (email: string, password: string, dispatch: Function) => {

    axios.post("http://localhost:5000/user/login",{
        email,
        password
    }).then((response) => {
        dispatch(session(response.data))
        sessionCookie(response.data)
        console.log(response.data)
    }).catch((error) => {
        console.log(error)
    })
};

export default loginService;