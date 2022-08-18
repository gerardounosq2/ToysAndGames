import { observer } from "mobx-react-lite";
import { Link, NavLink } from "react-router-dom";
import { Button, Table } from "semantic-ui-react";
import { ToysAndGames } from "../app/models/ToysAndGames";

interface Props {
    items?: ToysAndGames[]
}

const GridComponent = ({ items }: Props) => {
    return (
        <>
            <Button as={NavLink} to={'/create'} content="Add New" />
            <Table celled>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>Id</Table.HeaderCell>
                        <Table.HeaderCell>Name</Table.HeaderCell>
                        <Table.HeaderCell>Age</Table.HeaderCell>
                        <Table.HeaderCell>Price</Table.HeaderCell>
                        <Table.HeaderCell>Company</Table.HeaderCell>
                    </Table.Row>
                </Table.Header>
                <Table.Body>
                    {items?.map(r => (
                        <Table.Row key={r.id}>
                            <Table.Cell>{r.id}</Table.Cell>
                            <Table.Cell>{r.name}</Table.Cell>
                            <Table.Cell>{r.age}</Table.Cell>
                            <Table.Cell>{r.price}</Table.Cell>
                            <Table.Cell>{r.company}</Table.Cell>
                            <Table.Cell><Button as={Link} to={`/edit/${r.id}`} positive content="Update" /></Table.Cell>
                            <Table.Cell><Button negative content="Delete" /></Table.Cell>
                        </Table.Row>
                    ))}
                </Table.Body>
            </Table>
        </>
    )
}

export default observer(GridComponent);