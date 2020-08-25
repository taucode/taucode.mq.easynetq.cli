(defblock :name unsubscribe-all :is-top t
	(executor
		:executor-name unsubscribe-all
		:verb "uns"
		:description "Unsubscribes all handlers from subscriber."
		:usage-samples (
			"sub uns"))

	(end)
)
