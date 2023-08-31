import { session } from "../features/session/sessionSlice";

const setCookie = (cookie: any, dispatch: Function) => {

    try {
        JSON.parse(cookie);
        dispatch(session(JSON.parse(cookie)));
    } catch (e) {
        dispatch(session({
            email: "null",
            name: "null",
            surrname: "null",
            token: "null"
        }))
    }
}

export { setCookie }