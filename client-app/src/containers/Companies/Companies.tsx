import { Col, Container, Row } from "react-bootstrap";
import Sidebar from "../../components/SideBar";
import CompanyNavigator from "../../components/Company/CompanyNavigator/CompanyNavigator";

const Companies = ({theme}:any) => {

    return (
        <div className="companies">
            <div className="companies__sidebar"></div>
            <section className="companies__content">
                <CompanyNavigator />

            </section>
        </div>
    );
}

export default Companies;