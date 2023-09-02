
const CompanyNavigator = ({name, descriprion}:any) => {

    return (
        <nav className="companyNavigator">
            <ul className="companyNavigator__list">
                <li className="companyNavigator__item">Info</li>
                <li className="companyNavigator__item">Members</li>
                <li className="companyNavigator__item">Groups</li>
                <li className="companyNavigator__item">Activities</li>
            </ul>
        </nav>
    )
}

export default CompanyNavigator;