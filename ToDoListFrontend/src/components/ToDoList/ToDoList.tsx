import ListElement from "./ListElement/ListElement";
import type { IToDoInfo } from "../../models/IToDoInfo";
import useToDoInfo from "../../hooks/useToDoInfo";

const ToDoList = () => {
  const { loading, error, data } = useToDoInfo();
  return (
    <>
      {data === null
        ? "No data"
        : data.map((item: IToDoInfo) => (
            <ListElement
              key={item.id}
              title={item.title}
              description={item.discription}
              isDone={item.isDone}
            />
          ))}
    </>
  );
};

export default ToDoList;
