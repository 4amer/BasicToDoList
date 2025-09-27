interface IListElementProps {
  title: string;
  description: string;
  isDone: boolean;
}

const ListElement = ({ title, description, isDone }: IListElementProps) => {
  return (
    <div className="card">
      <div className="card-body">
        <h5 className="card-title">{title}</h5>
        <p className="card-text">{description}</p>
      </div>
    </div>
  );
};

export default ListElement;
