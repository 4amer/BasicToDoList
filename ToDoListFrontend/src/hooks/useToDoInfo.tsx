import { useEffect, useState } from "react";
import ToDoInfoAPI from "../services/ToDoInfoAPI";

const useToDoInfo = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [data, setData] = useState<any | null>(null);

  useEffect(() => {
    const loadData = async () => {
      try {
        setLoading(true);
        const data = await ToDoInfoAPI();
        setData(data);
      } catch (error: any) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };
    loadData();
  }, []);

  return { loading, error, data };
};

export default useToDoInfo;
